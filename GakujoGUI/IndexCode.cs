using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GakujoGUI
{
    partial class Index
    {
        public IndexData IndexData { get; }

        public Index(IndexData indexData)
        {
            IndexData = indexData;
        }
    }

    public sealed class IndexData
    {
        public List<ClassContact> ClassContactList { get; set; }
        public List<SchoolContact> SchoolContactList { get; set; }
        public List<Report> ReportList { get; set; }
        public List<Quiz> QuizList { get; set; }
        public List<ClassSharedFile> ClassFileList { get; set; }
        public List<SchoolSharedFile> SchoolFileList { get; set; }
    }
}
