using System;

namespace BinarySearchTreeP_R21_I_19
{
    class Node<T> : IComparable, IComparable<T>
        where T : IComparable, IComparable<T>
    {
        public T Data { get;   set; }
        public Node<T> Left { get; private set; }
        public Node<T> Right { get; private set; }
        public Node(){
            this.Left = null;
            this.Right = null;
        }
        public Node(T data)
        {
            Data = data;
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
    }
}
