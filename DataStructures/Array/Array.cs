using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Array
{
    public class Array<T> : IEnumerable<T>, ICloneable                                    //Numaralandırma yeteneği , Kopyalama yeteneği
    {
        private T[] InnerList;                                                             //Sınıf içindeki Liste
        public int Count { get; private set; }                                            //(prop) Dışardan okunabilir Sınıf içinde yazılabilir
        public int Capacity => InnerList.Length;                                         //Sadece okunabilir(get) dizinin boyutu

        public Array() {
            InnerList = new T[2];                                                       //InnerList başlatılıyor.
            Count = 0;
        }

        public Array(params T[] initial)                                                   //(Ctor)
        {
            InnerList = new T[initial.Length];                                          //Başlangıç değerinin uzunluğu olarak ayarladık.
            Count = 0;
            foreach (var item in initial)
            {
                Add(item);
            }
        }

        public Array(IEnumerable<T> colleciton)
        {
            InnerList = new T[colleciton.Count()];
            Count = 0;
            foreach(var item in colleciton)
            {
                Add(item);
            }
        }

        public void Add(T item)                                                          //Diziye Ekleme işlemi
        {
            if(InnerList.Length == Count)                                                 // Dizi dolduysa 
            {
                DoubleArray(); 
            }
            InnerList[Count] = item;                                                       // Counta(index olarak kullanıcaz) itemi atıyoruz.
            Count++;                                                                       // Count 1 artırıyoruz.
        }

        public T Remove()                                                                //Diziden son elemanı silme
        {
            if(Count == 0)                                                             //Dizi boş ise
            {
                throw new Exception("Dizide silinecek eleman yok!");
            }

            var temp = InnerList[Count-1];                                              //Count'dan önceki eleman son eleman 
            if (Count > 0)                  
            {
                Count--;                                                               //Count 1 azaltıyoruz.

            }                      

            if(InnerList.Length / 2 == Count)                                           //Dizinin yarısı veya daha azı doluysa
            {
                HalfArray();
            }
            return temp;                                                                //Silinen elemanı dönderiyoruz.

        }

        private void HalfArray()                                                     //Dinamik olarak dizinin boyutunu 2'ye bölme 
        {
            if (InnerList.Length > 2)
            {
                var temp = new T[InnerList.Length / 2];
                System.Array.Copy(InnerList, temp, temp.Length);
                InnerList = temp;
            }
        }

        private void DoubleArray()                                                     //Dinamik olarak dizinin boyutunu 2'ye katlama 
        {   
            var temp = new T[InnerList.Length * 2];                                  // Boyutu 2'ye katlayıp geçici değişkene atıyoruz.
            System.Array.Copy(InnerList, temp, InnerList.Length);                   //(Kaynak , hedef , kopyalama sayısı)
            InnerList = temp;
        }

        public object Clone()                                                     //Kopya Oluşturma
        {
            //return this.MemberwiseClone();                                             // Mevcut örneğin sığ kopyası döner.
            var arr = new Array<T>();                                                    // Mevcut örneğin dip kopyası oluşturulur.(Sığdan farkı herşey baştan oluşturulur.)
            foreach( var item in this)
            {
                arr.Add(item);
            }
            return arr;
        }                                       

        public IEnumerator<T> GetEnumerator()
        {
            return InnerList.Take(Count).GetEnumerator();                            //Count kadar eleman almasını istiyoruz (Boş yerleri döndermesin diye)
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
