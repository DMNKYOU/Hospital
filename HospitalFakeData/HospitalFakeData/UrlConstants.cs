using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMI.Hospital.MockHospitalData
{
    internal static class Patients
    {
        private const string Path = "api/v1/patients";

        public static string Get(string id) => $"{Path}/{id}";

        public static string Create => Path;

        public static string UpdateState => Path;

        public static string Delete(string id) => $"{Path}/{id}";
    }

    internal static class People
    {
        private const string Path = "api/v1/people";

        public static string Get(string id) => $"{Path}/{id}";

        public static string Create => Path;

        public static string Delete(string id) => $"{Path}/{id}";
    }
}
