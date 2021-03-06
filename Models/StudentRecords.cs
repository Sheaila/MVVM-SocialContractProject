using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM_SocialContractProject.Exceptions;
using MVVM_SocialContractProject.Models.Database;
using MySql.Data.MySqlClient;

namespace MVVM_SocialContractProject.Models
{
    public class StudentRecords
    {
        private readonly List<StudentInfo> _studentInfo;
        private readonly DatabaseQueries _dbQueries;
        private bool Result;

        public StudentRecords()
        {
            _studentInfo = new List<StudentInfo>();
            _dbQueries = new DatabaseQueries();
        }
        public IEnumerable<StudentInfo> GetStudentinfo(string StudentID)
        {
            _studentInfo.Clear();
            _dbQueries.GetStudentInfo(StudentID, _studentInfo);
            return _studentInfo.Where(r => r.StudentID == StudentID);
        }

        public IEnumerable<StudentInfo> GetAllStudentInfo(string SearchQuery, int page, int studentQuery, bool direction)
        {
            _studentInfo.Clear();
            _dbQueries.LoadStudentInfo(_studentInfo, SearchQuery, page, studentQuery,direction);
            return _studentInfo;
        }
        public IEnumerable<StudentInfo> SearchForStudentInfo(string StudentID)
        {
            _studentInfo.Clear();
            _dbQueries.SearchQueryStudent(_studentInfo, StudentID);
            return _studentInfo;
        }
        public SocialContract AddStudentInfo (StudentInfo StudentID, SocialContract socialContract, SocialContractMonitoringSystem scSystem)
        {
            foreach (StudentInfo existingStudentInfo in _studentInfo)
            {
                if (existingStudentInfo.Conflicts(StudentID))
                {
                    return scSystem.CreateSocialContract(socialContract, StudentID);
                   throw new StudentInfoConflictException(existingStudentInfo, StudentID);
                }
            }
                _dbQueries.InsertStudentRecords(StudentID);
                _studentInfo.Add(StudentID);
                return scSystem.CreateSocialContract(socialContract, StudentID);

        }

      
    }
}
