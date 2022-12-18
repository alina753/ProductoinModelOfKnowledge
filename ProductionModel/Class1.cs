using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionModel
{
    public class TreeFactsNode
    {
        public TreeFactsNode Parent { get; set; }
        public List<TreeFactsNode> Children { get; set; }
        public string Value { get; set; }
        public bool IsCover { get; set; }

        public TreeFactsNode(TreeFactsNode p, string v, List<TreeFactsNode> c)
        {
            this.Parent = p;
            this.Children = c;
            this.Value = v;
        }

        public TreeFactsNode(TreeFactsNode p, string v)
        {
            this.Parent = p;
            this.Value = v;
        }
        public TreeFactsNode(string v, List<TreeFactsNode> c)
        {
            this.Value = v;
            this.Children = c;
        }

        public TreeFactsNode(string v)
        {
            this.Value = v;
        }
    }
}
