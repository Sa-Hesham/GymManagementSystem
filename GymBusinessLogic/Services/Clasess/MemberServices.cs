using GymBusinessLogic.Services.Interfaces;
using GymBusinessLogic.ViewModels.MemberViewModel;
using GymDataAccsess.Models;
using GymDataAccsess.Repositres.Classes;
using GymDataAccsess.Repositres.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBusinessLogic.Services.Clasess
{
    internal class MemberServices : ImemberService
    {
        private readonly IRepositryGenaric<Member> memberRepositry;
        private readonly IRepositryGenaric<MemberShip> memberShipRepositry;
        private readonly IPlanRepositry planRepositry;
        private readonly IRepositryGenaric<MembersBookingSessions> memberSessionRepositry;

        public MemberServices(IRepositryGenaric<Member> memberRepositry, IRepositryGenaric<MemberShip> memberShipRepositry
            ,IPlanRepositry planRepositry,IRepositryGenaric<MembersBookingSessions>memberSessionRepositry)
        {
            this.memberRepositry = memberRepositry;
            this.memberShipRepositry = memberShipRepositry;
            this.planRepositry = planRepositry;
            this.memberSessionRepositry = memberSessionRepositry;
        }


        public bool CreateMember(CreateMemberViewModel createMember)
        {
            try
            {
                var EmailIsExist = memberRepositry.GetAll(x => x.Email == createMember.Email).Any();
                //cheakphone 
                var IsPhoneExist = memberRepositry.GetAll(x => x.Phone == createMember.phone).Any();
                if (IsPhoneExist || EmailIsExist) return false;


                Member member = new Member()
                {

                    Name = createMember.Name,
                    Email = createMember.Email,
                    Phone = createMember.phone,
                    Gendar = createMember.Gendar,
                    DateOfBirth = createMember.DateOfBirth,
                    Address = new Address()
                    {
                        BuildingNumber = createMember.BuildingNumber,
                        street = createMember.Street,
                        city = createMember.City,

                    },

                    HealthRecord = new HealthRecord()
                    {

                        Height = createMember.HelthRecordView.Heigth,
                        Weight = createMember.HelthRecordView.weigth,
                        BloodType = createMember.HelthRecordView.BloodType,
                        Notes = createMember.HelthRecordView.Note,




                    }









                };

                return memberRepositry.Add(member) > 0;


            }
            catch (Exception)
            {

                return false;
            }







        }

        public bool DeleteMember(int Memberid)
        {
          var member = memberRepositry.GetById(Memberid);   
            if (member == null) return false;
           
            var MemberHasSession=memberSessionRepositry.GetAll(x=>x.MemberId == Memberid && x.sessions.StartDate>DateTime.Now).Any();
            if(MemberHasSession)return false;

            var membership = memberShipRepositry.GetAll(x => x.MemberId == Memberid);
            try
            {
                foreach( var memberShip in membership)
                {
                    memberShipRepositry.Delete(memberShip);

                }

                return memberRepositry.Delete(member) > 0;

            }
            catch (Exception)
            {

                return false;
            }


        }


        public IEnumerable<GetAllMembersView> GetAll()
        {
            var Members = memberRepositry.GetAll();
            if (Members == null || !Members.Any())
            {
                return Enumerable.Empty<GetAllMembersView>();

            }

            #region FirstWay


            //var getAllMembersViews = new List<GetAllMembersView>();

            //foreach (var member in Members)
            //{

            //    GetAllMembersView membersview = new GetAllMembersView()
            //    {

            //        Name = member.Name,
            //        photo = member.Photo,
            //        phoneNumber = member.Phone,
            //        Email = member.Email,
            //        Gendar = member.Gendar.ToString(),




            //    };


            //    getAllMembersViews.Add(membersview);



            //}
            //return getAllMembersViews; 
            #endregion

            #region Secondway

           var memberviewmodels= Members.Select(m => new GetAllMembersView
            {
                Name = m.Name,  
                phoneNumber=m.Phone,
                photo=m.Photo,
                Email=m.Email,
                Gendar=m.Gendar.ToString(),




            });

            return memberviewmodels;

            #endregion

        }

        public GetAllMembersView? GetMemberDetails(int Memberid)
        {
            var member =memberRepositry.GetById(Memberid);
            if (member == null) return null;
            GetAllMembersView membersView=new GetAllMembersView() { 

               Name= member.Name,

               photo=member.Photo,

               Email=member.Email,

               Gendar = member.Gendar.ToString(),

               DateOfBirth=member.DateOfBirth.ToShortDateString(),

               Address =$"{member.Address.BuildingNumber } - {member.Address.street} - {member.Address.city}"
               
            
            
            
            };

            var membership = memberShipRepositry.GetAll(x=>x.MemberId == Memberid && x.Status =="Active")
                .FirstOrDefault();
            if(membership is not null)
            {
                membersView.MemberShipStartDate = membership.CreatedAt.ToShortDateString();
                membersView.MemberShipEndDate= membership.EndDate.ToShortDateString();
                var plan = planRepositry.getById(membership.PlanId);

                membersView.PlanName = plan?.Name;
              

            }

            return membersView;
        }

        public HelthRecordView? HelthRecordMember(int Memberid)
        {
          var member = memberRepositry.GetById(Memberid);   
            if (member == null) return null;
            HelthRecordView helthRecordView = new HelthRecordView()
            {
                
                Heigth=member.HealthRecord.Height,
                weigth=member.HealthRecord.Weight,
                BloodType=member.HealthRecord.BloodType,
                Note=member.HealthRecord.Notes  



            };

            return helthRecordView;
        }

        public MemberDataUpdateViewModel? upatedMember(int Memberid)
        {
            var memberview = memberRepositry.GetById(Memberid);
            if (memberview == null) return null;

        return new MemberDataUpdateViewModel() { 
           
           
           name = memberview.Name,  
           phone = memberview.Phone,
           Email = memberview.Email,
           Photo=memberview.Photo,
           BuildingNumber=memberview.Address.BuildingNumber,
           Street= memberview.Address.street,
           City= memberview.Address.city,   

           
           
           
           };


        }

        public bool UpdateMember(int id, MemberDataUpdateViewModel updateMember)
        {
            try
            {
                var IsEmailExist = memberRepositry.GetAll(x=>x.Email == updateMember.Email).Any();
                var IsphoneExist = memberRepositry.GetAll(x => x.Phone == updateMember.phone).Any();
                if (IsEmailExist || IsphoneExist) return false;
              
                var member = memberRepositry.GetById(id);
                if (member == null) return false;   

                member.Name=updateMember.name;
                member.Phone=updateMember.phone;
                member.Email=member.Email;
                member.Photo=member.Photo;
                member.Address.BuildingNumber=updateMember.BuildingNumber;
                member.Address.street=updateMember.Street;
                member.Address.city=updateMember.City;  
                member.HealthRecord.UpdatedAt=DateTime.Now; 


                return memberRepositry.Update(member) >0;



            }
            catch (Exception)
            {

               return false;
            }
        }
    }
}
