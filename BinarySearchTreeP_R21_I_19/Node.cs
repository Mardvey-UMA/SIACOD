using System;

namespace BinarySearchTreeP_R21_I_19
{
    class Node<T> : IComparable, IComparable<T>
        where T : IComparable, IComparable<T>
    {
        public T Data{ get;   set; }
        public Node<T> Left; //{ get; private set; }
        public Node<T> Right; //{ get; private set; }
        public int height;
        public int Height
        {
            get
            {
                return (this != null) ? this.height : 0;
            }
        }
        public int BalanceFactor
        {
            get
            {
                int rh = (this.Right != null) ? this.Right.Height : 0;
                int lh = (this.Left != null) ? this.Left.Height : 0;
                return rh - lh;
            }
        }
        public void NewHeight()
        {
            int rh = (this.Right != null) ? this.Right.Height : 0;
            int lh = (this.Left != null) ? this.Left.Height : 0;
            this.height = ((rh > lh) ? rh : lh) + 1;
        }
        public Node(){
            height = 1;
            this.Left = null;
            this.Right = null;
        }
        public Node(T data)
        {
            Data = data;
            height = 1;
            this.Left = null;
            this.Right = null;
        }
        public Node(T data, Node<T> left, Node<T> right)
        {
            Data = data;
            Left = left;
            Right = right;

        }
        public void Add(T data)
        {
            var node = new Node<T>(data);
            if (node.Data.CompareTo(Data) < 0) // новое значение меньше предка 
            {
                if (Left == null) // если нет левой ветки создаем ее
                {
                    Left = node;
                }
                else // если есть ветка возвращаемся к методу Add
                {
                    Left.Add(data);
                }
            }
            else // новое значение больше или равно предка
            {
                if (Right == null) // если нет правой ветки создаем ее
                {
                    Right = node;
                }
                else // если есть ветка добавляем к ней 
                {
                    Right.Add(data);
                }
            }
        }
        public static void RotationRight(ref Node<T> R){
            Node<T> x = R.Left;
            R.Left = x.Right;
            x.Right = R;
            R.NewHeight();
            x.NewHeight();
            R = x;
        }
        public static void RotationLeft(ref Node<T> R)
        {
            Node<T> x = R.Right;
            R.Right = x.Left;
            x.Left = R;
            R.NewHeight();
            x.NewHeight();
            R = x;
        }
        public static void InsertToRoot(ref Node<T> R, T item){
            if (R == null){
                R = new Node<T>(item);
            }else if (R.Data.CompareTo(item) > 0){
                InsertToRoot(ref R.Left, item);
                RotationRight(ref R);
            }else{
                InsertToRoot(ref R.Right, item);
                RotationLeft(ref R);
            }
        }
        public static Node<T> JoinTree(Node<T> firstTree, Node<T> secondTree){
            if (secondTree == null) return firstTree;
            if (firstTree == null) return secondTree;
            InsertToRoot(ref secondTree, firstTree.Data);
            secondTree.Left = JoinTree(firstTree.Left, secondTree.Left);
            secondTree.Right = JoinTree(firstTree.Right, secondTree.Right);
            return secondTree;
        }
       /* public static void InsertRandom(ref Node<T> r, T nodeData, Random rnd)
        {
            if (r == null)
            {
                r = new Node<T>(nodeData);
            }
            else
            {
                if (rnd.Next() < int.MaxValue \ (r.Count + 1)){

                }
            }
        }*/
        public int CompareTo(object obj)
        {
            if (obj is Node<T> item)
            {
                return Data.CompareTo(item.Data);
            }
            else
            {
                throw new Exception("Type error");
            }
        }
        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }

        public override string ToString()
        {
            return Data.ToString();
        }
        /*        public override int Parse()
                {
                    return Data.ToString().Parse();
                }*/
        public bool AddForBalancing(T data, out T optimalValue)
        {
            if (this.AddForBalancing(data, out optimalValue))
            {
                optimalValue = data;
                return true;
            }

            if (this.BalanceFactor == -2)
            {
                optimalValue = Left.Data;
                return false;
            }
            else if (this.BalanceFactor == 2)
            {
                optimalValue = Right.Data;
                return false;
            }

            optimalValue = default(T);
            return true;
        }
    }
}
