using BinarySearchTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace BinarySearchTreeTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //BinarySearchTree<int> tree = new BinarySearchTree<int> { 6, 10, 4, 1, 5, 8, 12 };
            //tree.Remove(5);
            //foreach (var item in tree.InOrder)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(tree.Count);

            //BinarySearchTree<int> tree = new BinarySearchTree<int>((i1, i2) => Math.Abs(i1) - Math.Abs(i2))
            //{ -6, -10, 4, -1, 5, -8, 12 };
            //tree.Remove(5);
            //foreach (var item in tree.InOrder)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(tree.Count);

            //BinarySearchTree<string> tree = new BinarySearchTree<string> { "Lion", "Owl", "Ara", "Cat" };
            //tree.Remove("Ara");
            //foreach (var item in tree.InOrder)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(tree.Count);

            //BinarySearchTree<string> tree = new BinarySearchTree<string>((i1, i2) => i1.Length - i2.Length) { "Lion", "Owl", "Ara", "Cat" };
            //Console.WriteLine(tree.Count);
            //tree.Remove("Ara");
            //foreach (var item in tree.InOrder)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(tree.Count);

            //Book book2 = new Book(4, "Fahrenheit 451", "Ray Bradbury", 2000);
            //Book book3 = new Book(2, "The Last of the Mohicans", "James Fenimore Cooper", 2012);
            //Book book4 = new Book(3, "The Old Man and the Sea", "Ernest Hemingway", 2005);
            //Book book5 = new Book(5, "The Adventures of Tom Sawyer", "Mark Twain", 2017);

            //BinarySearchTree<Book> tree = new BinarySearchTree<Book> { book2, book3, book4, book5 };
            //foreach (var item in tree.InOrder)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(tree.Count);

            //BookYearComparer comp = null;
            //BinarySearchTree<Book> tree = new BinarySearchTree<Book>(new BookYearComparer()) { book2, book3, book4, book5 };
            //foreach (var item in tree.InOrder)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(tree.Count);

            Point p1 = new Point(1, 1);
            Point p2 = new Point(2, 2);
            Point p3 = new Point(3, 3);
            Point p4 = new Point(4, 4);
            Point p5 = new Point(5, 5);
            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(new PointXComparer()) { p5, p2, p1, p4, p3, p5, p3 };
            foreach (var item in tree.InOrder)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(tree.Count);

            Console.ReadLine();
        }
    }
}
