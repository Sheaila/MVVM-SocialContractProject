﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_SocialContractProject.Models
{
   public class SocialContractMonitoringSystem
    {
        private readonly SocialContractRecords _socialContractRecord;

        private readonly StudentRecords _studentRecords;

        private readonly UserInfoRecords _userInfoRecord;

        private readonly PDFInfoRecords _pdfInfo;

        public SocialContractMonitoringSystem()
        {
            _socialContractRecord = new SocialContractRecords();
            _userInfoRecord = new UserInfoRecords();
            _studentRecords = new StudentRecords();
            _pdfInfo = new PDFInfoRecords();
        }

        public IEnumerable<SocialContract> GetSocialContractForUser(StudentInfo StudentID)
        {
            return _socialContractRecord.GetSocialRecords(StudentID);
        }
        public bool CreateSocialContract(SocialContract socialcontract)
        {
           return _socialContractRecord.AddSocialContract(socialcontract);
        }

        public IEnumerable<StudentInfo> GetStudentInfo(string StudentID)
        {
            return _studentRecords.GetStudentinfo(StudentID);
        }

        public void CreateStudentInfo(StudentInfo studentID, SocialContract socialContract, SocialContractMonitoringSystem scSystem)
        {
            _studentRecords.AddStudentInfo(studentID, socialContract, scSystem);
        }

        public IEnumerable<UserInfo> GetUserInfo(string Username)
        {
            return _userInfoRecord.GetUserInfo(Username);
        }

        public void CreateUserInfo(UserInfo user)
        {
            _userInfoRecord.AddUserInfo(user);
        }

        public IEnumerable<StudentInfo> GetAllStudentInfo(string searchQuery)
        {
            return _studentRecords.GetAllStudentInfo(searchQuery);
        }

        public IEnumerable<StudentInfo> SearchForUser(string StudentID)
        {
            return _studentRecords.SearchForStudentInfo(StudentID);
        }

        public void CreateEventPdf(PDFInfo pdf)
        {
            _pdfInfo.AddPDFEvent(pdf);
        }

        public IEnumerable<PDFInfo> GetAllPDF(string SearchQuery)
        {
            return _pdfInfo.GetAllEvents(SearchQuery);
        }




    }
}
