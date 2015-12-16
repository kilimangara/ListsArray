using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstrakt
{ public delegate void Showmessage(string message);
    public delegate string Readpar();
    public interface Ilists
    {
     void insert(int pos, Showmessage method, Readpar method1);
     void clear(Showmessage method);
      void read(Showmessage method);
      int Firstelem{get;set;}
      string El { get; set; }
     int Freel { get; set; }
    }
   public class lists:Ilists
    {
        const int imax = 50;
        public struct studentT
        {
            public string student;
            public int next;
        };
        studentT[] st = new studentT[imax];
        string el;
        private int count;
        private int firstel=0;
        private int freel=1;
        public string El

        {
            get
            {
                return el;
            }
            set
            {
                el = value;
            }
        }
        public int Firstelem
        {
            set
            {

                firstel = value;
            }
            get
            {
                return firstel;
            }
        }
       public int Freel
       {
           get
           {
               return freel;
           }
           set
           {
               freel=value;
           }
       }
       public lists()
       {
           for (int ab = 1; ab <= imax - 1; ++ab)
           {
               st[ab].next = ab + 1;
           }
           st[imax-1].next = 0;
       }
       private void Create(Showmessage method, Readpar method1)
       {
           count = 1;
           for(int u=1;u<=imax-1;u++)
           {
               if(st[u].next==2)
               {
                   this.firstel=u;
               }
           }
            method("Введите значение первого элемента");
            el = method1();
            st[firstel].student = el;
            freel = st[firstel].next;
            st[firstel].next = 0;
        }
        public void insert(int pos,Showmessage method,Readpar method1)
        { int i=1;
        int tmp;
        int a = firstel;
            if (firstel != 0)
            {
                 if ((pos < 0) || ((pos-1) > count))
            {
                method(string.Format("Недопустимое значение pos"));
                return;
            }
                if (pos == 1)
                {
                    method(string.Format("Введите первый элемент"));
                    el=method1();
                    st[freel].student = el;
                    tmp = st[freel].next;
                    st[freel].next = firstel;
                    this.firstel=freel;
                    freel = tmp;
                    ++count;
                    method(string.Format("Элемент вставлен"));
                }
                else
                {
                    if ((pos-1) == count)
                    {
                        while (st[a].next!=0)
                        {
                            a = st[a].next;
                        }
                        st[a].next = freel;
                        method("Введите следующий элемент");
                        el = method1(); 
                        st[freel].student = el;
                        tmp = st[freel].next;
                        st[freel].next = 0;
                        freel = tmp;
                        count++;
                        method(string.Format("Элемент добавлен"));
                    }
                    else
                    {
                        while (i < pos-1)
                        {
                            a = st[a].next;
                            ++i;
                        }
                        method("Введите элемент для вставки");
                        el = method1();
                        st[freel].student = el;
                        tmp = st[freel].next;
                        st[freel].next = st[a].next;
                       st[a].next=freel;
                       freel = tmp;
                        count++;
                        method(string.Format("Элемент вставлен"));
                    }

                }
            }
            else
            {
                Create(method,method1);
                method(string.Format("Список создан"));
            }
        }
        public void clear(Showmessage method)
        {
            int b = firstel;
            firstel = 0;
            if (b != 0)
            {
                    while (st[b].student != null)
                    {
                        st[b].next = 0;
                        st[b].student = null;
                        b = st[b].next;
                        
                    }
                   method(string.Format("Список очищен"));
                   this.firstel = 0;
                return;
            }
            method(string.Format("Список пуст"));
        }


        public void read(Showmessage method)
        { int b=firstel;
        int k = 1;
            if (firstel != 0)
            {
                while (st[b].next != 0)
                {
                        method(string.Format("Элемент №{0} {1}", k, st[b].student));
                        b = st[b].next;
                        ++k;
                }
                method(string.Format("Элемент №{0} {1}", k, st[b].student));
                return;
            }
            method("Список пуст");
        }

    }
}
