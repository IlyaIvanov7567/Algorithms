using System;

namespace Lesson2_Task1
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }

    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    class DoubleLinkList : ILinkedList
    {
        public Node head;
        public Node tail;
        public int GetCount() // возвращает количество элементов в списке
        {
            int count = 0;
            Node currentNode;

            if (head != null)
            {
                currentNode = head;
                while (currentNode != null)
                {
                    currentNode = currentNode.NextNode;
                    count++;
                }
            }
            return count;
        }

        public void AddNode(int value) // добавляет новый элемент списка
        {
            Node newNode = new Node { Value = value };
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                tail.NextNode = newNode;
                newNode.PrevNode = tail;
            }
            tail = newNode;
        }
        public void AddNodeAfter(Node node, int value) // добавляет новый элемент списка после определённого элемента
        {
            Node newNode = new Node { Value = value };
            var nextNode = node.NextNode;
            node.NextNode = newNode;
            newNode.PrevNode = node;
            newNode.NextNode = nextNode;
        }
        public void RemoveNode(int index) // удаляет элемент по порядковому номеру
        {
            if (index == 0)
            {
                head = head.NextNode;
            }

            int currentIndex = 0;
            Node currentNode = head;
            while (currentNode != null)
            {
                if (currentIndex == index)
                {
                    RemoveNode(currentNode);
                }
                currentNode = currentNode.NextNode;
                currentIndex++;
            }
        }
        public void RemoveNode(Node node) // удаляет указанный элемент
        {

            if (node == head)
            {
                head = node.NextNode;
            }
            else if (node == tail)
            {
                tail = node.PrevNode;
                tail.NextNode = null;
            }
            else
            {
                Node nextNode = node.NextNode;
                Node prevNode = node.PrevNode;
                nextNode.PrevNode = prevNode;
                prevNode.NextNode = nextNode;
            }

        }
        public Node FindNode(int searchValue) // ищет элемент по его значению
        {
            Node currentNode = head;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(searchValue))
                {
                    return currentNode;
                }
                currentNode = currentNode.NextNode;
            }
            return null;
        }
    }
}

