using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PetClinics
{
    public class Person : IComparable<Person>, IEquatable<Person>
    {
        public string name;
        public int age;
        public string kind;

        public int CompareTo(Person other)
        {
            if (this.name != other.name)
            {
                return this.name.CompareTo(other.name);
            }

            return this.age.CompareTo(other.age);
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode() ^ this.age.GetHashCode();
        }

        public bool Equals(Person other)
        {
            if (this.name == other.name && this.age == other.age)
            {
                return true;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            var other = (Person)obj;
            return this.name == other.name && this.age == other.age;
        }

        public override string ToString()
        {
            return $"{this.name} {this.age} {this.kind}";
        }
    }

    public class Clinic<Person> : IEnumerable<Person>
    {
        private Person[] list;
        private int pointer;
        private int capacity;
        private int[] addCounters;
        private int[] removeCounters;

        public string name;

        public Clinic(string name, int capacity)
        {
            this.Capacity = capacity;
            this.list = new Person[capacity];
            this.addCounters = SeedCounters();
            this.removeCounters = SeedRemoveCounters();
            this.pointer = 0;
            this.name = name;
        }

        private int[] SeedRemoveCounters()
        {
            var list = new List<int>(capacity);

            for (int i = capacity / 2; i < capacity; i++)
            {
                list.Add(i);
            }

            for (int i = 0; i < capacity / 2; i++)
            {
                list.Add(i);
            }

            return list.ToArray();
        }

        private int[] SeedCounters()
        {
            var list = new List<int>();

            int counter = capacity/2;

            list.Add(counter);

            for (int i = 1; i <= counter; i++)
            {
                list.Add(counter - i);
                list.Add(counter + i);
            }

            return list.ToArray();
        }

        public Person this[int index]
        {
            get
            {
                if (index < 0 || this.Capacity <= index)
                {
                    throw new IndexOutOfRangeException("Invalid Operation!");
                }

                return this.list[index];
            }
        }

        public int Capacity
        {
            get { return this.capacity; }

            set
            {
                if (value % 2 == 0)
                {
                    throw new AggregateException("Invalid Operation!");
                }

                this.capacity = value;
            }
        }

        public bool HasEmptyRoom => pointer < this.Capacity;

        public int AddCount => addCounters[pointer];
        public int RemoveCount => addCounters[pointer];

        public string Add(Person element)
        {
            if (element == null)
            {
                return "False";
                throw new AggregateException("Invalid Operation!");
            }

            if (this.pointer >= capacity)
            {
                return "False";
                throw new AggregateException("Invalid Operation!");
            }

            this.list[AddCount] = element;
            this.pointer++;
            return "True";
        }

        public string Remove()
        {
            Person[] newArray = new Person[this.list.Length];
            

            for (int i = capacity / 2; i < capacity; i++)
            {
                if (list[i] != null)
                {
                    Array.Copy(this.list, 0, newArray, 0, i);
                    Array.Copy(this.list, i + 1, newArray, i + 1, this.Capacity - i - 1);

                    this.list = newArray;
                    pointer--;
                    return "True";
                }
            }

            for (int i = 0; i < capacity / 2; i++)
            {
                if (list[i] != null)
                {
                    Array.Copy(this.list, 0, newArray, 0, i);
                    Array.Copy(this.list, i + 1, newArray, i + 1, this.Capacity - i - 1);

                    this.list = newArray;
                    pointer--;
                    return "True";
                }
            }

            return "False";
        }

        public IEnumerator<Person> GetEnumerator()
        {
            for (int i = 0; i <= list.Length - 1; i ++)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var pets = new List<Person>();
            var clinics = new List<Clinic<Person>>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                switch (command)
                {
                    case "Create":
                        string type = tokens[1];
                        if (type == "Pet")
                        {
                            var pet = new Person();
                            pet.name = tokens[2];
                            pet.age = int.Parse(tokens[3]);
                            pet.kind = tokens[4];

                            pets.Add(pet);
                        }
                        else if(type == "Clinic")
                        {
                            string name = tokens[2];
                            int capacity = int.Parse(tokens[3]);
                            try
                            {
                                var clinic = new Clinic<Person>(name, capacity);

                                clinics.Add(clinic);
                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case "Add":
                        string petName = tokens[1];
                        string clinicName = tokens[2];

                        var currPet = pets.FirstOrDefault(p => p.name == petName);
                        var currClinic = clinics.FirstOrDefault(p => p.name == clinicName);

                        if (currClinic != null)
                        {
                            Console.WriteLine(currClinic.Add(currPet));
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        
                        break;
                    case "Release":
                        clinicName = tokens[1];
                        currClinic = clinics.FirstOrDefault(p => p.name == clinicName);
                        Console.WriteLine(currClinic.Remove());
                        break;
                    case "HasEmptyRooms":
                        clinicName = tokens[1];
                        currClinic = clinics.FirstOrDefault(p => p.name == clinicName);

                        if (currClinic == null)
                        {
                            Console.WriteLine("Invalid Operation!"); 
                        }
                        else
                        {
                            Console.WriteLine(currClinic.HasEmptyRoom); 
                        }
                        break;
                    case "Print":
                        clinicName = tokens[1];
                        currClinic = clinics.FirstOrDefault(p => p.name == clinicName);

                        if (tokens.Length == 2)
                        {
                            foreach (var room in currClinic)
                            {
                                if (room == null)
                                {
                                    Console.WriteLine("Room empty");
                                }
                                else
                                {
                                    Console.WriteLine(room.ToString());
                                }
                            }
                        }
                        else
                        {
                            int room = int.Parse(tokens[2]) - 1;

                            try
                            {
                                var currRoom = currClinic[room];

                                if (currRoom == null)
                                {
                                    Console.WriteLine("Room empty");
                                }
                                else
                                {
                                    Console.WriteLine(currRoom.ToString());
                                }
                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                }
            }


        }
    }
}
