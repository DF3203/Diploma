// <autogenerated>
namespace Server.Infrastructure.Test.Models
{
    using Server.Infrastructure.Models;
    using Server.DataBaseCore.Entities;
    using Xunit;

    public class PatientModelFixure
    {
        [Fact]
        public void CreatedObject_NotNull()
        {
            PatientViewModel p = new PatientViewModel();
            Assert.NotNull(p);
        }

        [Fact]
        public void CanChangePatientModel()
        {
            PatientViewModel testPatient = new PatientViewModel
            {
                PatientId = 1,
                FirstName = "Andrew",
                LastName = "Moshko",
                MiddleName = "Victor",
                Age = "18",
                Weight = "83",
                Height = "195",
                Email = "dron@gmail.com",
                PhoneNumber = "+380995135682",
                HomeNumber = "-",
                Sex = "man",
                Condition = "lazy student with diploma in front of his nose"
            };

            testPatient.Email = "pro100takvoin@gmail.com";

            Assert.Equal("pro100takvoin@gmail.com", testPatient.Email);
            Assert.Equal(1, testPatient.PatientId);
            Assert.Equal("Andrew", testPatient.FirstName);
            Assert.Equal("Moshko", testPatient.LastName);
            Assert.Equal("Victor", testPatient.MiddleName);
            Assert.Equal("18", testPatient.Age);
            Assert.Equal("83", testPatient.Weight);
            Assert.Equal("195", testPatient.Height);
            Assert.Equal("+380995135682", testPatient.PhoneNumber);
            Assert.Equal("-", testPatient.HomeNumber);
            Assert.Equal("man", testPatient.Sex);
            Assert.Equal("lazy student with diploma in front of his nose", testPatient.Condition);

            //Patient patient = testPatient.ToEntity();

            //PatientViewModel patientViewModel = new PatientViewModel();

            //patientViewModel.ToModel(patient);

            //Assert.Equal(testPatient.PatientId, patient.PatientId);

            //Assert.Equal(patient.Height, patientViewModel.Height);
        }

        [Fact]
        public void ToEntity_PatientEqualsViewModel()
        {
            PatientViewModel testPatient = new PatientViewModel
            {
                PatientId = 1,
                FirstName = "Andrew",
                LastName = "Moshko",
                MiddleName = "Victor",
                Age = "18",
                Weight = "83",
                Height = "195",
                Email = "dron@gmail.com",
                PhoneNumber = "+380995135682",
                HomeNumber = "-",
                Sex = "man",
                Condition = "lazy student with diploma in front of his nose"
            };

            Patient patient = testPatient.ToEntity();

            Assert.Equal(testPatient.PatientId, patient.PatientId);
            Assert.Equal(testPatient.FirstName, patient.FirstName);
            Assert.Equal(testPatient.LastName, patient.LastName);
            Assert.Equal(testPatient.MiddleName, patient.MiddleName);
            Assert.Equal(testPatient.Age, patient.Age);
            Assert.Equal(testPatient.Weight, patient.Weight);
            Assert.Equal(testPatient.Height, patient.Height);
            Assert.Equal(testPatient.PhoneNumber, patient.PhoneNumber);
            Assert.Equal(testPatient.HomeNumber, patient.HomeNumber);
            Assert.Equal(testPatient.Sex, patient.Sex);
            Assert.Equal(testPatient.Condition, patient.Condition);
        }

        [Fact]
        public void ToModel_ViewModelEqualsPatient()
        {
            Patient testPatient = new Patient
            {
                PatientId = 1,
                FirstName = "Andrew",
                LastName = "Moshko",
                MiddleName = "Victor",
                Age = "18",
                Weight = "83",
                Height = "195",
                Email = "dron@gmail.com",
                PhoneNumber = "+380995135682",
                HomeNumber = "-",
                Sex = "man",
                Condition = "lazy student with diploma in front of his nose"
            };

            PatientViewModel patient = new PatientViewModel();
            patient.ToModel(testPatient);

            Assert.Equal(patient.PatientId, testPatient.PatientId);
            Assert.Equal(patient.FirstName, testPatient.FirstName);
            Assert.Equal(patient.LastName, testPatient.LastName);
            Assert.Equal(patient.MiddleName, testPatient.MiddleName);
            Assert.Equal(patient.Age, testPatient.Age);
            Assert.Equal(patient.Weight, testPatient.Weight);
            Assert.Equal(patient.Height, testPatient.Height);
            Assert.Equal(patient.PhoneNumber, testPatient.PhoneNumber);
            Assert.Equal(patient.HomeNumber, testPatient.HomeNumber);
            Assert.Equal(patient.Sex, testPatient.Sex);
            Assert.Equal(patient.Condition, testPatient.Condition);
           // Assert.Equal(patient.IsActive, testPatient.IsActive);

        }

        //[Fact]
        //public void CanChangeDoctorModel()
        //{
        //    DoctorViewModel testDoctor = new DoctorViewModel
        //    {
        //        DoctorId = 1,
        //        FirstName = "Andrew",
        //        LastName = "Moshko",
        //        MiddleName = "Victor",
        //        Age = "18",
        //        Weight = "83",
        //        Height = "195",
        //        Email = "dron@gmail.com",
        //        PhoneNumber = "+380995135682",
        //        HomeNumber = "-",
        //        Sex = "man",
        //        Condition = "test Doctor",
        //        Text = "not null"
        //    };

        //    testDoctor.Email = "email@gmail.com";

        //    Assert.NotEqual("pro100takvoin@gmail.com", testDoctor.Email);

        //    Assert.Equal("not null", testDoctor.Text);

        //    Doctor doctor = testDoctor.ToEntity();

        //    DoctorViewModel doctorViewModel = new DoctorViewModel();

        //    doctorViewModel.ToModel(doctor);

        //    Assert.Equal(testDoctor.DoctorId, doctor.DoctorId);

        //    Assert.Equal(doctor.Sex, doctorViewModel.Sex);
        //}
    }
}