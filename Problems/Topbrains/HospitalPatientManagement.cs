using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalPatientManagementSystem
{
    // Patient Class
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Condition { get; set; }
        public List<string> MedicalHistory { get; set; }

        public Patient(int id, string name, int age, string condition)
        {
            Id = id;
            Name = name;
            Age = age;
            Condition = condition;
            MedicalHistory = new List<string>();
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Age: {Age}, Condition: {Condition}";
        }
    }

    // HospitalManager Class
    public class HospitalManager
    {
        private Dictionary<int, Patient> _patients;
        private Queue<Patient> _appointmentQueue;

        public HospitalManager()
        {
            _patients = new Dictionary<int, Patient>();
            _appointmentQueue = new Queue<Patient>();
        }

        // 1. Register Patient
        public void RegisterPatient(int id, string name, int age, string condition)
        {
            if (_patients.ContainsKey(id))
            {
                Console.WriteLine($"✗ Error: Patient with ID {id} already exists.");
                return;
            }

            Patient patient = new Patient(id, name, age, condition);
            _patients.Add(id, patient);
            Console.WriteLine($"✓ Patient registered: {name} (ID: {id})");
        }

        // 2. Schedule Appointment
        public void ScheduleAppointment(int patientId)
        {
            if (!_patients.ContainsKey(patientId))
            {
                Console.WriteLine($"✗ Error: Patient with ID {patientId} not found.");
                return;
            }

            Patient patient = _patients[patientId];
            _appointmentQueue.Enqueue(patient);
            Console.WriteLine($"✓ Appointment scheduled for: {patient.Name}");
        }

        // 3. Process Next Appointment
        public Patient ProcessNextAppointment()
        {
            if (_appointmentQueue.Count == 0)
            {
                Console.WriteLine("✗ No appointments scheduled.");
                return null;
            }

            Patient nextPatient = _appointmentQueue.Dequeue();
            Console.WriteLine($"✓ Processing appointment for: {nextPatient.Name}");
            return nextPatient;
        }

        // 4. Find Patients by Condition
        public List<Patient> FindPatientsByCondition(string condition)
        {
            var matchingPatients = _patients.Values
                .Where(p => p.Condition.Equals(condition, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return matchingPatients;
        }

        // Bonus: Add Medical History
        public void AddMedicalHistory(int patientId, string history)
        {
            if (!_patients.ContainsKey(patientId))
            {
                Console.WriteLine($"✗ Error: Patient with ID {patientId} not found.");
                return;
            }

            Patient patient = _patients[patientId];
            patient.MedicalHistory.Add(history);
            Console.WriteLine($"✓ Medical history added for: {patient.Name}");
        }

        // Bonus: Display All Pending Appointments
        public void DisplayPendingAppointments()
        {
            if (_appointmentQueue.Count == 0)
            {
                Console.WriteLine("No pending appointments.");
                return;
            }

            Console.WriteLine($"\n========== PENDING APPOINTMENTS ({_appointmentQueue.Count}) ==========");
            int position = 1;
            foreach (Patient patient in _appointmentQueue)
            {
                Console.WriteLine($"{position}. {patient.Name} - {patient.Condition}");
                position++;
            }
            Console.WriteLine("==============================================\n");
        }

        // Bonus: Display Total Registered Patients
        public void DisplayTotalPatients()
        {
            Console.WriteLine($"Total Registered Patients: {_patients.Count}");
        }

        // Bonus: Find Oldest Patient
        public Patient FindOldestPatient()
        {
            if (_patients.Count == 0)
            {
                return null;
            }

            return _patients.Values.OrderByDescending(p => p.Age).FirstOrDefault();
        }

        // Bonus: Group Patients by Condition
        public Dictionary<string, List<Patient>> GroupPatientsByCondition()
        {
            var groupedPatients = _patients.Values
                .GroupBy(p => p.Condition)
                .ToDictionary(g => g.Key, g => g.ToList());

            return groupedPatients;
        }

        // Display All Patients
        public void DisplayAllPatients()
        {
            if (_patients.Count == 0)
            {
                Console.WriteLine("No patients registered.");
                return;
            }

            Console.WriteLine("\n========== ALL REGISTERED PATIENTS ==========");
            foreach (var patient in _patients.Values)
            {
                Console.WriteLine(patient);
                if (patient.MedicalHistory.Count > 0)
                {
                    Console.WriteLine($"   Medical History: {string.Join(", ", patient.MedicalHistory)}");
                }
            }
            Console.WriteLine("=============================================\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HospitalManager manager = new HospitalManager();

            Console.WriteLine("========== HOSPITAL PATIENT MANAGEMENT SYSTEM ==========\n");

            // Test Case 1: Register Patients
            Console.WriteLine("--- Registering Patients ---");
            manager.RegisterPatient(1, "John Doe", 45, "Hypertension");
            manager.RegisterPatient(2, "Jane Smith", 32, "Diabetes");
            manager.RegisterPatient(3, "Bob Johnson", 58, "Diabetes");
            manager.RegisterPatient(4, "Alice Williams", 67, "Arthritis");
            manager.RegisterPatient(5, "Charlie Brown", 29, "Hypertension");
            Console.WriteLine();

            // Test duplicate ID
            Console.WriteLine("--- Testing Duplicate Registration ---");
            manager.RegisterPatient(1, "Duplicate Person", 40, "Test");
            Console.WriteLine();

            // Test Case 2: Add Medical History
            Console.WriteLine("--- Adding Medical History ---");
            manager.AddMedicalHistory(1, "High BP treatment started 2020");
            manager.AddMedicalHistory(1, "Regular checkup 2025");
            manager.AddMedicalHistory(2, "Insulin therapy initiated");
            manager.AddMedicalHistory(3, "Diet plan recommended");
            Console.WriteLine();

            // Display all patients
            manager.DisplayAllPatients();

            // Test Case 3: Schedule Appointments
            Console.WriteLine("--- Scheduling Appointments ---");
            manager.ScheduleAppointment(1);
            manager.ScheduleAppointment(2);
            manager.ScheduleAppointment(3);
            manager.ScheduleAppointment(99); // Non-existent patient
            Console.WriteLine();

            // Display pending appointments
            manager.DisplayPendingAppointments();

            // Test Case 4: Process Next Appointment
            Console.WriteLine("--- Processing Appointments (FIFO) ---");
            Patient nextPatient1 = manager.ProcessNextAppointment();
            Console.WriteLine($"Processed: {nextPatient1.Name}\n");

            Patient nextPatient2 = manager.ProcessNextAppointment();
            Console.WriteLine($"Processed: {nextPatient2.Name}\n");

            // Display remaining appointments
            manager.DisplayPendingAppointments();

            // Test Case 5: Find Patients by Condition
            Console.WriteLine("--- Finding Patients with Diabetes ---");
            List<Patient> diabeticPatients = manager.FindPatientsByCondition("Diabetes");
            Console.WriteLine($"Found {diabeticPatients.Count} patient(s) with Diabetes:");
            foreach (var patient in diabeticPatients)
            {
                Console.WriteLine($"  - {patient.Name} (Age: {patient.Age})");
            }
            Console.WriteLine();

            // Bonus: Find patients with Hypertension (case-insensitive)
            Console.WriteLine("--- Finding Patients with hypertension (case-insensitive) ---");
            List<Patient> hyperPatients = manager.FindPatientsByCondition("hypertension");
            Console.WriteLine($"Found {hyperPatients.Count} patient(s):");
            foreach (var patient in hyperPatients)
            {
                Console.WriteLine($"  - {patient.Name}");
            }
            Console.WriteLine();

            // Bonus: Display Total Patients
            Console.WriteLine("--- Total Patient Count ---");
            manager.DisplayTotalPatients();
            Console.WriteLine();

            // Bonus: Find Oldest Patient
            Console.WriteLine("--- Finding Oldest Patient ---");
            Patient oldest = manager.FindOldestPatient();
            if (oldest != null)
            {
                Console.WriteLine($"Oldest Patient: {oldest.Name}, Age: {oldest.Age}");
            }
            Console.WriteLine();

            // Bonus: Group Patients by Condition
            Console.WriteLine("--- Patients Grouped by Condition ---");
            var groupedPatients = manager.GroupPatientsByCondition();
            foreach (var group in groupedPatients)
            {
                Console.WriteLine($"{group.Key}: {group.Value.Count} patient(s)");
                foreach (var patient in group.Value)
                {
                    Console.WriteLine($"  - {patient.Name}, Age: {patient.Age}");
                }
            }
            Console.WriteLine();

            // Process remaining appointments
            Console.WriteLine("--- Processing Remaining Appointments ---");
            while (true)
            {
                Patient next = manager.ProcessNextAppointment();
                if (next == null)
                {
                    break;
                }
            }
            Console.WriteLine();

            Console.WriteLine("========== END OF HOSPITAL MANAGEMENT DEMO ==========");
            Console.ReadLine();
        }
    }
}
