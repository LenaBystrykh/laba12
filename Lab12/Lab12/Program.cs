using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10for12;

namespace Lab12
{
    class Program
    {
        static Random rnd = new Random();
        //сравнение выполняется по оценкам
        static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            int choice = -1;
            while (choice != 5)
            {
                Console.WriteLine("Введите цифру, соответствующую необходимому действию");
                Console.WriteLine("1. Работа с однонаправленным списком");
                Console.WriteLine("2. Работа с двунаправленным списком");
                Console.WriteLine("3. Работа с бинарным деревом");
                Console.WriteLine("4. Работа с коллекцией");
                Console.WriteLine("5. Выход");
                bool ok = int.TryParse(Console.ReadLine(), out choice);
                if (!ok)
                {
                    do
                    {
                        Console.WriteLine("Проверьте правильность ввода");
                        ok = int.TryParse(Console.ReadLine(), out choice);
                    } while (!ok || choice < 0 || choice > 5);
                }

                switch (choice)
                {
                    case 1:
                        LinkedList();
                        break;
                    case 2:
                        DoublyLinkedList();
                        break;
                    case 3:
                        BinaryTreeMenu();
                        break;
                    case 4:
                        StackMenu();
                        break;
                    case 5:
                        choice = 5;
                        break;
                }
            }
        }
        public static void LinkedList()
        {
            TrialLinkedList<Trial> list = new TrialLinkedList<Trial>();
            list.Beg = list.MakeList(5);
            Point<Trial> beg = list.Beg;
            int choice = -1;
            while (choice != 4)
            {
                Console.WriteLine("1. Печать");
                Console.WriteLine("2. Добавление элемента после заданного");
                Console.WriteLine("3. Удалить список из памяти");
                Console.WriteLine("4. Назад");

                bool ok = int.TryParse(Console.ReadLine(), out choice);
                if (!ok)
                {
                    do
                    {
                        Console.WriteLine("Проверьте правильность ввода");
                        ok = int.TryParse(Console.ReadLine(), out choice);
                    } while (!ok || choice < 0 || choice > 4);
                }

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        list.ShowList(list.Beg);
                        break;
                    case 2:
                        Console.WriteLine("Введите номер элемента, после которого необходимо добавить элемент");
                        int num;
                        ok = int.TryParse(Console.ReadLine(), out num);
                        if (!ok)
                        {
                            do
                            {
                                Console.WriteLine("Проверьте правильность ввода");
                                ok = int.TryParse(Console.ReadLine(), out num);
                            } while (!ok || num < 0);
                        }
                        list.AddPoint(beg, num, rnd);
                        break;
                    case 3:
                        list.Beg = null;
                        Console.WriteLine("Удаление выполнено");
                        break;
                    case 4:
                        choice = 4;
                        Console.Clear();
                        break;
                }
            }
        }
        public static void DoublyLinkedList()
        {
            DoublyLinkedList<Trial> list = new DoublyLinkedList<Trial>();
            list.Beg = list.MakeList(7);
            PointDouble<Trial> beg = list.Beg;
            int choice = -1;
            while (choice != 4)
            {
                Console.WriteLine("1. Печать");
                Console.WriteLine("2. Удаление элементов с чётными инф. полями");
                //за чётные инф.поля для класса Trial будут приниматься чётные значения оценок
                Console.WriteLine("3. Удаление списка из памяти");
                Console.WriteLine("4. Назад");

                bool ok = int.TryParse(Console.ReadLine(), out choice);
                if (!ok)
                {
                    do
                    {
                        Console.WriteLine("Проверьте правильность ввода");
                        ok = int.TryParse(Console.ReadLine(), out choice);
                    } while (!ok || choice < 0 || choice > 4);
                }
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        list.ShowList(list.Beg);
                        break;
                    case 2:
                        list.Beg = list.DeleteElements(list.Beg);
                        Console.WriteLine("Удаление выполнено");
                        break;
                    case 3:
                        list.Beg = null;
                        Console.WriteLine("Удаление выполнено");
                        break;
                    case 4:
                        choice = 4;
                        Console.Clear();
                        break;
                }
            }
        }
        public static void BinaryTreeMenu()
        {
            PointTree<Trial> root = new PointTree<Trial>(new Trial(rnd.Next(1, 30), rnd.Next(1, 12), rnd.Next(0, 10)));
            Tree<Trial> tr = new Tree<Trial>(root);
            root = tr.IdealTree(15, root, rnd);
            int choice = -1;
            while (choice != 5)
            {
                Console.WriteLine("1. Печать");
                Console.WriteLine("2. Найти высоту дерева");
                Console.WriteLine("3. Преобразовать в дерево поиска");
                Console.WriteLine("4. Удалить из памяти");
                Console.WriteLine("5. Назад");

                bool ok = int.TryParse(Console.ReadLine(), out choice);
                if (!ok)
                {
                    do
                    {
                        Console.WriteLine("Проверьте правильность ввода");
                        ok = int.TryParse(Console.ReadLine(), out choice);
                    } while (!ok || choice < 0 || choice > 5);
                }
                switch (choice)
                {
                    case 1:
                        tr.ShowTree(root, 3);
                        break;
                    case 2:
                        Console.WriteLine("Высота дерева = " + tr.TreeDeep(root));
                        break;
                    case 3:
                        PointTree<Trial> searchTree = tr.first(root.Data);
                        tr.MakeSearch(root, searchTree);
                        root = searchTree;
                        tr.ShowTree(root, 3);
                        break;
                    case 4:
                        tr = null;
                        Console.WriteLine("Удаление выполнено");
                        break;
                    case 5:
                        choice = 5;
                        Console.Clear();
                        break;
                }
            }
        }
        public static void StackMenu()
        {
            MyStack<Trial> m = new MyStack<Trial>();
            int choice = -1;
            while (choice != 9)
            {
                Console.WriteLine("1. Печать");
                Console.WriteLine("2. Подсчёт количества элементов в коллекции");
                Console.WriteLine("3. Добавить элементы");
                Console.WriteLine("4. Удалить элементы");
                Console.WriteLine("5. Найти элемент по значению");
                Console.WriteLine("6. Выполнить клонирование");
                Console.WriteLine("7. Выполнить поверхностное копирование");
                Console.WriteLine("8. Удалить коллекцию из памяти");
                Console.WriteLine("9. Назад");

                bool ok = int.TryParse(Console.ReadLine(), out choice);
                if (!ok)
                {
                    do
                    {
                        Console.WriteLine("Проверьте правильность ввода");
                        ok = int.TryParse(Console.ReadLine(), out choice);
                    } while (!ok || choice < 0 || choice > 9);
                }

                switch (choice)
                {
                    case 1:
                        m.Show();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Количество элементов коллекции = " + m.Count());
                        break;
                    case 3:
                        Console.WriteLine("Введите количество элементов, которое необходимо добавить");
                        int num;
                        bool boo = int.TryParse(Console.ReadLine(), out num);
                        if (!boo)
                        {
                            do
                            {
                                Console.WriteLine("Проверьте правильность ввода");
                                boo = int.TryParse(Console.ReadLine(), out num);
                            } while (!boo || num < 0);
                        }
                        m.Add(num, rnd);
                        Console.Clear();
                        Console.WriteLine($"Добавление {num} элементов выполнено");
                        break;
                    case 4:
                        int capacity = m.Count();
                        Console.WriteLine("Введите количество элементов, которое необходимо удалить");
                        int number;
                        boo = int.TryParse(Console.ReadLine(), out number);
                        if (!boo || number < 0 || number > capacity)
                        {
                            do
                            {
                                Console.WriteLine("Проверьте правильность ввода");
                                boo = int.TryParse(Console.ReadLine(), out number);
                            } while (!boo || number < 0 || number > capacity);
                        }
                        m.Delete(number);
                        Console.Clear();
                        Console.WriteLine($"Удаление {number} элементов выполнено");
                        break;
                    case 5:
                        Console.WriteLine("Введите значение Trial");
                        Console.WriteLine("День:");
                        int d = int.Parse(Console.ReadLine());
                        Console.WriteLine("Месяц:");
                        int mo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Оценка:");
                        int ma = int.Parse(Console.ReadLine());
                        Trial trial = new Trial(d, mo, ma);
                        m.Search(trial);
                            break;
                    case 6:
                        MyStack<Trial> newCollection = (MyStack<Trial>)m.Clone();
                        Console.WriteLine("Клонирование выполнено");
                        Console.WriteLine("Текущая коллекция:");
                        m.Show();
                        Console.WriteLine();
                        Console.WriteLine("Клонированная коллекция:");
                        newCollection.Show();
                        break;
                    case 7:
                        MyStack<Trial> copyCollection = m.ShallowCopy();
                        Console.WriteLine("Копирование выполнено");
                        Console.WriteLine("Текущая коллекция:");
                        m.Show();
                        Console.WriteLine();
                        Console.WriteLine("Копированная коллекция:");
                        copyCollection.Show();
                        break;
                    case 8:
                        m.Delete();
                        break;
                    case 9:
                        choice = 9;
                        Console.Clear();
                        break;
                }
            }
        }
    }

    public class Point<T>
    {
        public object Data { get; set; }
        public Point<T> Next { get; set; }

        public Point()
        {
            Next = null;
            Data = default(T);
        }

        public Point(T data)
        {
            Data = data;
            Next = null;
        }

        public Point(Random rnd)
        {
            Trial t = new Trial(rnd.Next(1, 30), rnd.Next(1, 12), rnd.Next(0, 10));
            Data = t;
            Next = null;
        }

        public override string ToString()
        {
            return Data.ToString() + " ";
        }
    }

    public class PointDouble<T>
    {
        public T Data { get; set; }
        public PointDouble<T> Next { get; set; }
        public PointDouble<T> Pred { get;set; }

        public PointDouble()
        {
            Next = null;
            Pred = null;
            Data = default(T);
        }

        public PointDouble(T data)
        {
            Data = data;
            Next = null;
            Pred = null;
        }

        public override string ToString()
        {
            return Data.ToString() + " ";
        }
    }

    public class PointTree<T>
    {
        public Trial Data;
        public PointTree<T> left,//адрес левого поддерева 
                            right;//адрес правого поддерева
        public PointTree()
        {
            Data = null;
            left = null;
            right = null;
        }
        public PointTree(Trial t)
        {
            Data = t;
            left = null;
            right = null;
        }
        public override string ToString()
        {
            return Data.ToString() + " ";
        }
    }

    public class TrialLinkedList<T>
    {
        public Point<T> Beg { get; set; }

        public TrialLinkedList()
        {
            Beg = null;
        }

        public TrialLinkedList(Point<T> data)
        {
            Beg = data;
        }

        public TrialLinkedList(TrialLinkedList<T> list)
        {
            Beg = list.Beg;
        }

        public TrialLinkedList(int size)
        {
            this.Beg = this.MakeList(size);
        }

        public TrialLinkedList(Random rnd)
        {
            Point<T> p = new Point<T>(rnd);
            Beg = p;
        }

        public Point<T> MakePoint(T tr)
        {
            Point<T> p = new Point<T>(tr);
            return p;
        }

        public Point<T> MakePoint(Random rnd)
        {
            Point<T> p = new Point<T>(rnd);
            return p;
        }
        //добавление в начало однонаправленного списка
        public Point<T> MakeList(int size)
        {
            Random rnd = new Random();
            Point<T> beg = MakePoint(rnd);//создаем первый элемент
            Console.WriteLine("The element \"{0}\" is adding...", beg.Data);
            for (int i = 1; i < size; i++)
            {
                //создаем элемент и добавляем в начало списка
                Point<T> p = MakePoint(rnd);
                Console.WriteLine("The element \"{0}\" is adding...", p.Data);
                //создаем элемент и добавляем в начало списка
                p.Next = beg;
                beg = p;
            }
            return beg;
        }
        public void ShowList(Point<T> Beg)
        {
            //проверка наличия элементов в списке
            if (Beg == null)
            {
                Console.WriteLine("The List is empty");
                return;
            }
            Point<T> p = Beg;
            while (p != null)
            {
                Console.WriteLine(p);
                p = p.Next;//переход к следующему элементу
            }
            Console.WriteLine();
        }
        public Point<T> AddPoint(Point<T> beg, int number, Random rnd)
        {
            //создаем новый элемент
            Point<T> NewPoint = MakePoint(rnd);
            Console.WriteLine("The element \"{0}\" is adding...", NewPoint.Data);
            if (beg == null)//список пустой
            {
                beg = MakePoint(rnd);
                return beg;
            }
            if (number == 1) //добавление в начало списка
            {
                NewPoint.Next = beg;
                beg = NewPoint;
                return beg;
            }
            //вспом. переменная для прохода по списку
            Point<T> p = beg;
            //идем по списку до нужного элемента
            for (int i = 1; i < number && p != null; i++)
                p = p.Next;
            if (p == null)//элемент не найден
            {
                Console.WriteLine("Error! The size of List less than Number");
                return beg;
            }
            //добавляем новый элемент
            NewPoint.Next = p.Next;
            p.Next = NewPoint;
            Console.WriteLine("Элемент добавлен");
            return beg;
        }
        public Point<T> DeletePoint(Point<T> beg, int number)
        {
            if (beg == null)//пустой список
            {
                Console.WriteLine("Error! The List is empty");
                return null;
            }
            if (number == 1)//удаляем первый элемент
            {
                beg = beg.Next;
                return beg;
            }
            Point<T> p = beg;
            //ищем элемент для удаления и встаем на предыдущий
            for (int i = 1; i < number - 1 && p != null; i++)
                p = p.Next;
            if (p == null)//если элемент не найден
            {
                Console.WriteLine("Error! The size of List less than Number");
                return beg;
            }
            //исключаем элемент из списка
            p.Next = p.Next.Next;
            return beg;
        }
    }

    public class DoublyLinkedList<T>
    {
        public PointDouble<Trial> Beg { get; set; }

        public DoublyLinkedList()
        {
            Beg = null;
        }

        public DoublyLinkedList(PointDouble<Trial> data)
        {
            Beg = data;
        }

        public DoublyLinkedList(DoublyLinkedList<Trial> list)
        {
            Beg = list.Beg;
        }


        public PointDouble<Trial> MakePoint(Trial tr)
        {
            PointDouble<Trial> t = new PointDouble<Trial>(tr);
            return t;
        }
        //формирование двунаправленного списка
        public PointDouble<Trial> MakeList(int size) //добавление в начало
        {
            Random rnd = new Random();
            int d = rnd.Next(1, 30);
            int mo = rnd.Next(1, 12);
            int ma = rnd.Next(1, 10);
            Trial trial1 = new Trial(d, mo, ma);
            PointDouble<Trial> beg = MakePoint(trial1);
            Console.WriteLine("The element \"{0}\" is adding...", trial1.data);

            PointDouble<Trial> tHelp = beg;

            for (int i = 1; i < size; i++)
            {
                d = rnd.Next(1, 30);
                mo = rnd.Next(1, 12);
                ma = rnd.Next(1, 10);
                Trial trial2 = new Trial(d, mo, ma);
                PointDouble<Trial> tr = MakePoint(trial2);
                Console.WriteLine("The element \"{0}\" is adding...", trial2.data);
                tr.Next = tHelp;
                tHelp.Pred = tr;
                tHelp = tr;
            }
            return beg;
        }
        public void ShowList(PointDouble<Trial> beg)
        {
            Console.Clear();
            //проверка наличия элементов в списке
            if (beg == null)
            {
                Console.WriteLine("The List is empty");
                return;
            }
            PointDouble<Trial> p = beg;
            while (p != null)
            {
                Console.WriteLine(p);
                p = p.Pred;//переход к следующему элементу назад
            }
            Console.WriteLine();
        }
        public PointDouble<Trial> DeleteElements(PointDouble<Trial> beg)
        {
            //проверка наличия элементов в списке
            if (beg == null)
            {
                Console.WriteLine("The List is empty");
                return beg;
            }
            PointDouble<Trial> p = beg;
            while (p != null)
            {
                if (p.Data.Mark == 0 || p.Data.Mark == 2 || p.Data.Mark == 4 || p.Data.Mark == 6 || p.Data.Mark == 8 || p.Data.Mark == 10)
                {
                    if (p.Pred == null) //последний элемент?
                    {
                        PointDouble<Trial> tHelp = p.Next;
                        tHelp.Pred = null;
                        p.Next.Pred = null;
                        return beg;
                    }
                    else
                    {
                        if (p.Next == null) //первый элемент?
                        {
                            PointDouble<Trial> tHelp = p.Pred;
                            tHelp.Next = null;
                            p.Pred.Next = null;
                            p.Next = null;
                            beg = p.Pred;
                            p = p.Pred;
                        }
                        else
                        {
                            PointDouble<Trial> tHelp1 = p.Pred;
                            PointDouble<Trial> tHelp2 = p.Next;
                            tHelp1.Next = p.Next;
                            tHelp2.Pred = p.Pred;
                            p.Pred.Next = p.Next;
                            p.Next.Pred = p.Pred;
                            p = p.Pred;
                        }
                    }
                }
                else
                {
                    p = p.Pred;//переход к следующему элементу
                }
            }
            Console.WriteLine();
            return beg;
        }

    }

    public class Tree<T>
    {
        public PointTree<Trial> Root { get; set; }

        public Tree()
        {
            Root = null;
        }
        public Tree(PointTree<Trial> t)
        {
            Root = t;
        }

        public PointTree<Trial> first(Trial tr)
        {
            PointTree<Trial> t = new PointTree<Trial>(tr);
            return t;
        }
        //добавление элемента d в дерево поиска
        public PointTree<Trial> Add(PointTree<Trial> root, Trial trial)
        {
            PointTree<Trial> p = root; //корень дерева
            PointTree<Trial> r = null;
            //флаг для проверки существования элемента d в дереве
            bool ok = false;
            while (p != null && !ok)
            {
                r = p;
                //элемент уже существует
                if (trial == p.Data) ok = true;
                else
            if (trial.Mark < p.Data.Mark) p = p.left; //пойти в левое поддерево
                else p = p.right; //пойти в правое поддерево
            }
            if (ok) return p;//найдено, не добавляем
                             //создаем узел
            PointTree<Trial> NewPoint = new PointTree<Trial>(trial);//выделили память
                                                                    // если d<r.key, то добавляем его в левое поддерево
            if (trial.Mark < r.Data.Mark) r.left = NewPoint;
            // если d>r.key, то добавляем его в правое поддерево
            else r.right = NewPoint;
            return NewPoint;
        }
        //построение идеально сбалансированного дерева
        public PointTree<Trial> IdealTree(int size, PointTree<Trial> root, Random rnd)
        {
            PointTree<Trial> r;
            int nl, nr;
            if (size == 0)
            {
                root = null;
                return root;
            }
            nl = size / 2;
            nr = size - nl - 1;
            r = new PointTree<Trial>(new Trial(rnd.Next(1, 30), rnd.Next(1, 12), rnd.Next(0, 10)));
            for (int i = 0; i < size; i++)
            {
                r.left = IdealTree(nl, r.left, rnd);
                r.right = IdealTree(nr, r.right, rnd);
            }
            return r;
        }
        public PointTree<Trial> MakeFirstTree()
        {
            Random rnd = new Random();
            PointTree<Trial> root = first(new Trial(rnd.Next(1, 30), rnd.Next(1, 12), rnd.Next(0, 10)));
            Add(root, new Trial(rnd.Next(1, 30), rnd.Next(1, 12), rnd.Next(0, 10)));
            Add(root, new Trial(rnd.Next(1, 30), rnd.Next(1, 12), rnd.Next(0, 10)));
            Add(root, new Trial(rnd.Next(1, 30), rnd.Next(1, 12), rnd.Next(0, 10)));
            Add(root, new Trial(rnd.Next(1, 30), rnd.Next(1, 12), rnd.Next(0, 10)));
            Add(root, new Trial(rnd.Next(1, 30), rnd.Next(1, 12), rnd.Next(0, 10)));
            Add(root, new Trial(rnd.Next(1, 30), rnd.Next(1, 12), rnd.Next(0, 10)));
            Add(root, new Trial(rnd.Next(1, 30), rnd.Next(1, 12), rnd.Next(0, 10)));
            Add(root, new Trial(rnd.Next(1, 30), rnd.Next(1, 12), rnd.Next(0, 10)));
            return root;
        }
        /*рекурсивная функция для печати дерева по уровням с обходом слева направо*/
        public void ShowTree(PointTree<Trial> p, int l)
        {
            if (p != null)
            {
                ShowTree(p.left, l + 5);//переход к левому поддереву
                                        //формирование отступа
                for (int i = 0; i < l; i++) Console.Write(" ");
                Console.WriteLine(p.Data);//печать узла
                ShowTree(p.right, l + 5);//переход к правому поддереву
            }
        }
        public void Run(PointTree<Trial> t)
        {
            if (t != null)
            {
                Run(t.left);//переход к левому поддереву
                Run(t.right);//переход к правому поддереву
            }
        }
        public int TreeDeep(PointTree<Trial> root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(TreeDeep(root.left), TreeDeep(root.right));
            }
        }
        public void MakeSearch(PointTree<Trial> root, PointTree<Trial> searchTree)
        {

            if (root != null)
            {
                MakeSearch(root.left, searchTree);
                Add(searchTree, root.Data);
                MakeSearch(root.right, searchTree);
                Add(searchTree, root.Data);
            }
        }
    }

    public class MyStack<T> : IEnumerable<T>, ICloneable
    {
        public TrialLinkedList<T> StackList;
        public MyStack() //предназначен для создания пустой коллекции.
        {
            StackList = new TrialLinkedList<T>();
        }
        public MyStack(int capacity) // создает пустую коллекцию с начальной емкостью, заданной параметром capacity.
        {
            StackList = new TrialLinkedList<T>(capacity);
        }
        public MyStack(MyStack<T> c) //служит для создания коллекции, которая инициализируется элементами
                                            //и емкостью коллекции, заданной параметром с.
        {
            TrialLinkedList<T> newList = c.StackList;
        }

        public int Count()
        {
            int count = 0;
            //проверка наличия элементов в списке
            if (StackList.Beg == null)
            {
                count = 0;
                return count;
            }
            Point<T> p = StackList.Beg;
            while (p != null)
            {
                count++;
                p = p.Next;//переход к следующему элементу
            }
            return count;
        }

        public MyStack<T> ShallowCopy()
        {
            return (MyStack<T>)this.MemberwiseClone();
        }

        public MyStack<T> Add(int num, Random rnd)
        {
            for (int i = 0; i < num; i++)
            {
                this.StackList.Beg = this.StackList.AddPoint(StackList.Beg, 1, rnd);
            }
            return this;
        }
        public MyStack<T> Delete(int num)
        {
            for (int i = 0; i < num; i++)
            {
                this.StackList.Beg = this.StackList.DeletePoint(StackList.Beg, 1);
            }
            return this;
        }

        public void Search(T trial)
        {
            bool ok = false;
            foreach(T item in this)
            {
                if (item.Equals(trial))
                {
                    ok = true;
                }
            }
            if (ok == true) Console.WriteLine("Элемент входит в коллекцию");
            else Console.WriteLine("Элемент не входит в коллекцию");
            return;
        }

        public void Show()
        {
            foreach (T item in this)
            {
                Console.WriteLine(item);
            }
        }
        public object Clone()
        {
            MyStack<T> cloneStack = new MyStack<T>(this);
            cloneStack.StackList = new TrialLinkedList<T>();
            cloneStack.StackList.Beg = this.StackList.Beg;
            return cloneStack;
        }
        public MyStack<T> Delete()
        {
            StackList.Beg = null;
            Console.Clear();
            Console.WriteLine("Коллекция удалена");
            return this;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = StackList.Beg;
            while (current != null)
            {
                yield return (T)current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public interface ICloneable
        {
            object Clone();
        }
    }
}
