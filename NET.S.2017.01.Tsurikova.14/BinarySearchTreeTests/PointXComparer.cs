using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeTests
{
    public class PointXComparer : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            return x.X - y.X;
        }
    }
}
