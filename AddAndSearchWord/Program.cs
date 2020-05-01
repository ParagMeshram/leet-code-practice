using System.Collections.Generic;

namespace AddAndSearchWord
{
    internal class Program
    {
        private static void Main(string[] args)
        {
        }
    }

    public class WordDictionary
    {
        private readonly Trie trie = new Trie();

        /** Initialize your data structure here. */
        public WordDictionary()
        {
            trie = new Trie();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            this.trie.Add(word);
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            return this.trie.Search(word);
        }
    }

    public class Trie
    {
        private Node root;

        public Trie()
        {
            this.root = new Node('^', -1);
        }

        public void Add(string word)
        {
            var trav = this.root;

            foreach (var ch in word)
            {
                if (!trav.Children.ContainsKey(ch))
                {
                    trav.AddChildren(ch, trav.Depth + 1);
                    trav = trav.Children[ch];
                }
            }
        }

        public bool Search(string word)
        {
            return MatchPattern(word, 0, this.root);
        }

        private bool MatchPattern(string word, int matchCount, Node node)
        {
            if (matchCount == word.Length) return node.IsLeaf;

            return (!node.IsLeaf);
        }

        private class Node
        {
            public char Value { get; }
            public Dictionary<char, Node> Children { get; }
            public int Depth { get; }

            public bool IsLeaf => Children.Count == 0;

            public Node(char value, int depth)
            {
                this.Value = value;
                this.Children = new Dictionary<char, Node>();
                this.Depth = depth;
            }

            public bool ContainsChildren(char child)
            {
                return this.Children.ContainsKey(child);
            }

            public void AddChildren(char ch, int depth)
            {
                if (!this.Children.ContainsKey(ch))
                    this.Children[ch] = new Node(ch, depth);
            }

            public override int GetHashCode()
            {
                return this.Value.GetHashCode();
            }
        }
    }
}