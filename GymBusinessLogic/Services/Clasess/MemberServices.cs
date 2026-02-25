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
    public class MemberServices : ImemberService
    {
 
     

        private readonly IUnitOfWork unitOfWork;
        

        public MemberServices(IUnitOfWork unitOfWork )
        {
            this.unitOfWork = unitOfWork;
         
        }


        public bool CreateMember(CreateMemberViewModel createMember)
        {
            try
            {
                var EmailIsExist =unitOfWork.GetRepositry<Member>().GetAll(x => x.Email == createMember.Email).Any();
                //cheakphone 
                var IsPhoneExist = unitOfWork.GetRepositry<Member>().GetAll(x => x.Phone == createMember.phone).Any();
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

                unitOfWork.GetRepositry<Member>().Add(member);
                return unitOfWork.saveCahnges()>0;

            }
            catch (Exception)
            {

                return false;
            }







        }

        public bool DeleteMember(int Memberid)
        {
          var member = unitOfWork.GetRepositry<Member>().GetById(Memberid);   
            if (member == null) return false;
           
            var MemberHasSessionIds= unitOfWork.GetRepositry<MembersBookingSessions>()
                .GetAll(x=>x.MemberId == Memberid )
                .Select(x=>x.SessionId);

            var HasFutureSessions = unitOfWork.SessionRepositry.GetAll(x => MemberHasSessionIds.Contains(x.Id) && x.StartDate > DateTime.Now);
            if(HasFutureSessions.Any()) return false;

            var membership = unitOfWork.GetRepositry<MemberShip>().GetAll(x => x.MemberId == Memberid);
            try
            {
                foreach( var memberShip in membership)
                {
                    unitOfWork.GetRepositry<MemberShip>().Delete(memberShip);

                }

               unitOfWork.GetRepositry<Member>().Delete(member) ;
                return unitOfWork.saveCahnges() > 0;    

            }
            catch (Exception)
            {

                return false;
            }


        }


        public IEnumerable<GetAllMembersView> GetAll()
        {
            var Members = unitOfWork.GetRepositry<Member>().GetAll();
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
                Id=m.Id,




            });

            return memberviewmodels;

            #endregion

        }

        public GetAllMembersView? GetMemberDetails(int Memberid)
        {
            var member = unitOfWork.GetRepositry<Member>().GetById(Memberid);
            if (member == null) return null;
            GetAllMembersView membersView=new GetAllMembersView() { 

               Name= member.Name,

               photo=member.Photo,

               Email=member.Email,

               Gendar = member.Gendar.ToString(),

               DateOfBirth=member.DateOfBirth.ToShortDateString(),

               phoneNumber=member.Phone.ToString(),

               Address =$"{member.Address.BuildingNumber } - {member.Address.street} - {member.Address.city}"
               
            
            
            
            };

            var membership = unitOfWork.GetRepositry<MemberShip>().GetAll(x=>x.MemberId == Memberid && x.Status =="Active")
                .FirstOrDefault();
            if(membership is not null)
            {
                membersView.MemberShipStartDate = membership.CreatedAt.ToShortDateString();
                membersView.MemberShipEndDate= membership.EndDate.ToShortDateString();
                var plan = unitOfWork.GetRepositry<Plan>().GetById(membership.PlanId);

                membersView.PlanName = plan?.Name;
              

            }

            return membersView;
        }

        public HelthRecordView? HelthRecordMember(int Memberid)
        {
          var member = unitOfWork.GetRepositry<Member>().GetById(Memberid);   
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
            var memberview = unitOfWork.GetRepositry<Member>().GetById(Memberid);
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
                var IsEmailExist = unitOfWork.GetRepositry<Member>()
                    .GetAll(x => x.Email == updateMember.Email && x.Id !=id);
                var IsphoneExist = unitOfWork.GetRepositry<Member>()
                    .GetAll(x => x.Phone == updateMember.phone && x.Id != id);
               
                if(IsEmailExist.Any() || IsphoneExist.Any()) return false;
              
                var member = unitOfWork.GetRepositry<Member>().GetById(id);
                if (member == null) return false;   

                member.Name=updateMember.name;
                member.Phone=updateMember.phone;
                member.Email=member.Email;
                member.Photo=member.Photo;
                member.Address.BuildingNumber=updateMember.BuildingNumber;
                member.Address.street=updateMember.Street;
                member.Address.city=updateMember.City;  
                member.HealthRecord.UpdatedAt=DateTime.Now;


                return unitOfWork.saveCahnges() > 0;



            }
            catch (Exception)
            {

               return false;
            }
        }
    }
}
