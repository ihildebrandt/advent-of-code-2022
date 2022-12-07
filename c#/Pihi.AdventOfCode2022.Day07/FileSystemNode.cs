using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pihi.AdventOfCode2022.Day07
{
    internal class FileSystemNode
    {
        private readonly int _size;

        public FileSystemNode? Parent { get; set; }
        public List<FileSystemNode> Children { get; } = new List<FileSystemNode>();

        public string Name { get; }

        public char Type { get; }

        public int Size 
        { 
            get
            {
                if (_size == 0)
                {
                    return Children.Sum(c => c.Size);
                }
                else
                {
                    return _size;
                }
            }
        }

        public FileSystemNode(string name)
        {
            Name = name;
        }

        public FileSystemNode(string name, FileSystemNode parent)
        {
            Name = name;
            Parent = parent;
        }

        public FileSystemNode(string name, FileSystemNode parent, int size)
        {
            Name = name;
            Parent = parent;
            _size = size;
        }

        public IEnumerable<FileSystemNode> FindDirectories()
        {
            if (_size == 0)
            {
                yield return this;
                foreach (var child in Children)
                {
                    foreach (var directory in child.FindDirectories())
                    {
                        yield return directory;
                    }
                }
            }
        }
    }
}
