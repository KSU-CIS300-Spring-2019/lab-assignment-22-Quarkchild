/* TrieWithOneChild.cs
 * Author: Michael Crisp
 * Date: 25 March 2019
 * 
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Indicates whether the node contains the empty string.
        /// </summary>
        private bool _hasEmpty;

        /// <summary>
        /// The only node of this Trie, an ITrie as it could be either
        /// implementation.
        /// </summary>
        private ITrie _onlyChild;

        /// <summary>
        /// The label of this child.
        /// </summary>
        private char _childLabel;

        public TrieWithOneChild(string s, bool isEmpty)
        {
            if(s == "" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }

            _hasEmpty = isEmpty;
            _childLabel = s[0];
            _onlyChild = new TrieWithNoChildren().Add(s.Substring(1));
        }
        
        public ITrie Add(string s)
        {
            if(s == "")
            {
                _hasEmpty = true;
                return this;
            }

            else if(s[0] == _childLabel)
            {
                _onlyChild = _onlyChild.Add(s.Substring(1));
                return this;
            }

            else
            {
                return new TrieWithManyChildren(s, _hasEmpty, _childLabel, _onlyChild);
            }
        }

        public bool Contains(string s)
        {
            if(s == "")
            {
                return _hasEmpty;
            }

            if(s[0] == _childLabel)
            {
                return _onlyChild.Contains(s.Substring(1));
            }

            else
            {
                return false;
            }
        }
    }
}
