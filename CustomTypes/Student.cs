using System;

namespace CustomTypes
{
    public class Student : IComparable
    {
        public Student()
        {
            
        }
        public Student(int ID, string Name, double GPA)
        {
            this.ID = ID;
            this.Name = Name;
            this.GPA = GPA;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }

        public int CompareTo(object? obj)
        {
            var other = (Student)obj;
            //if(this.GPA < other.GPA)
            //{
            //    return -1;
            //}
            //else if (this.GPA.Equals(other.GPA))
            //{
            //    return 0;
            //}
            //else
            //{
            //    return 1;
            //}
            return this.GPA.CompareTo(other.GPA); //(Üstteki açıklama satırları ile aynı işlemi yapıyor.!) GPA 'ya göre sıralama
            //return this.Name.CompareTo(other.Name); //İsme göre sıralama.
            //return this.ID.CompareTo(other.ID); //ID 'ye göre sıralama.
            
        }

        public override string ToString()
        {
            return $"{ID,-5}  {Name,-15}  {GPA,-5}";
        }
    }
}