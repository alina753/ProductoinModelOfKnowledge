using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace ProductionModel
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// facts selected by user
        /// </summary>
        List<string> using_facts = new List<string>();
        /// <summary>
        /// rules used in reverse output
        /// </summary>
        List<string> used_rules = new List<string>();
        /// <summary>
        /// [name, id]
        /// </summary>
        Dictionary<string, string> facts = new Dictionary<string, string>();
        /// <summary>
        /// [id, name]
        /// </summary>
        Dictionary<string, string> inverseDic_facts;
        
        /// <summary>
        /// rules[id] = [rule:THEN-part, IF-part]
        /// </summary>
        Dictionary<string, List<string>> rules = new Dictionary<string, List<string>>();
        public Form1()
        {
            InitializeComponent();
            listBox1_facts_completion();
            Rules_completion();
        }

        private void listBox1_facts_completion()
        {
            string file_name = "FactsForProductions.txt";
            string lines = File.ReadAllText(file_name);

            Regex regex_names = new Regex(@"'.+'");
            MatchCollection matches_names;

            Regex regex_ids = new Regex(@"[A-Z]\d+");
            MatchCollection matches_ids;

            matches_names = regex_names.Matches(lines);
            matches_ids = regex_ids.Matches(lines);
            
            int i = 0;
            foreach (Match match_id in matches_ids)
            {
                string id = match_id.Value;
                string name = matches_names[i].Value;
                //заполняем словарь фактов
                facts[name] = id;
                i++;

                //заполняем окно фактов
                listBox1.Items.Add(name);

                //заполняем список фактов
                listBox5.Items.Add(name);
            }

            inverseDic_facts = facts.ToDictionary(g => g.Value,g => g.Key);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            string fact = listBox1.SelectedItem.ToString();
            string fact_id = facts[fact].ToString();
            if (listBox2.Items.Contains(fact))
            {
                listBox2.Items.Remove(fact);
                using_facts.Remove(fact_id);
            }
            else
            {
                listBox2.Items.Add(fact);
                using_facts.Add(fact_id);
            }
        }

        private void using_facts_completion()
        {
            for( int i = 1; i < listBox2.Items.Count; i++)
            {
                string fact = listBox2.Items[i].ToString();
                string fact_id = facts[fact].ToString();

                if (!using_facts.Contains(fact))
                {
                    using_facts.Add(fact_id);
                }
            }
        }

        private void Rules_completion()
        {
            string file_name = "RulesForProductions.txt";
            string lines = File.ReadAllText(file_name);

            Regex regex_if = new Regex(@"[A-Z]\d+,[A-Z]\d+");
            MatchCollection matches_if;

            Regex regex_then = new Regex(@"- [A-Z]\d+");
            MatchCollection matches_then;

            Regex regex_id = new Regex(@"[A-Z]\d+ :");
            MatchCollection matches_id;

            matches_if = regex_if.Matches(lines);
            matches_then = regex_then.Matches(lines);
            matches_id = regex_id.Matches(lines);

            int i = 0;
            foreach (Match match_if in matches_if)
            {
                List<string> if_facts = match_if.Value.Split(',').ToList();
                string then_fact = matches_then[i].Value.Substring(2);
                string id = matches_id[i].Value.Substring(0, matches_id[i].Value.Length - 2);
                //заполняем словарь правил
                //rules[then_fact] = if_facts;

                List<string> rules_facts = new List<string>();
                rules_facts.Add(then_fact);
                for(int j = 0; j < if_facts.Count; j++)
                {
                    rules_facts.Add(if_facts[j]);
                }
                rules[id] = rules_facts;

                i++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//прямой вывод
        {
            label1.Text = "Прямой вывод";
            listBox3.Items.Clear();
            listBox4_rules.Items.Clear();

            direct_output();
        }

        private void direct_output()
        {
            int depth = 0;
            int k = -1;

            for (int i = 0; i < using_facts.Count; i++)
            {
                TreeFactsNode fact = new TreeFactsNode(using_facts[i], new List<TreeFactsNode>());
                Addition_using_facts_recurse(fact);
            }

            foreach (var rule in rules)
            {
                k++;
                List<string> cur_facts = new List<string>();
                for(int i = 1; i < rule.Value.Count; i++)//факты текущего правила
                {
                    cur_facts.Add(rule.Value[i]);
                }
                
                int count_match = 0;
                for (int i = 0; i < cur_facts.Count; i++)
                {
                    for (int j = 0; j < using_facts.Count; j++)
                    {
                        if (using_facts[j] == cur_facts[i])
                        {
                            count_match++;
                            if (count_match == cur_facts.Count)
                            {
                                using_facts.Add(rule.Value[0]);
                                if(!listBox3.Items.Contains(inverseDic_facts[rule.Value[0]]))
                                    listBox3.Items.Add(inverseDic_facts[rule.Value[0]]);
                                Print(k);
                                depth++;
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//Обратный вывод
        {
            label1.Text = "Обратный вывод";
            listBox3.Items.Clear();
            listBox4_rules.Items.Clear();

            if(listBox5.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите элемент для обратного вывода.");
                return;
            }

            using_facts.Clear();
            using_facts_completion();
            //раскладываем выбранные факты на составляющие
            for (int i = 0; i < using_facts.Count; i++)
            {
                TreeFactsNode fact = new TreeFactsNode(using_facts[i], new List<TreeFactsNode>());
                Addition_using_facts_recurse(fact);
            }

            string id_fact = facts[listBox5.SelectedItem.ToString()];
            List<TreeFactsNode> children = new List<TreeFactsNode>();
            TreeFactsNode root = new TreeFactsNode(id_fact, children);
            
            Recurse(root);

            if (root.IsCover == true)
            {
                label_res_reverse_output.Text = "Из выбранных фактов вывод возможен";
                Print(root);
            }
            else
                label_res_reverse_output.Text = "Из выбранных фактов вывод невозможен";

        }
        /// <summary>
        /// раскладывает выбранные пользоввателем факты до атомарных и добавляет в using_facts
        /// </summary>
        /// <param name="root"></param>
        private void Addition_using_facts_recurse(TreeFactsNode root)
        {
            for (int i = 0; i < rules.Keys.Count; i++)//идем по правилам
            {
                string key_fact = rules.ElementAt(i).Value[0];
                if (key_fact == root.Value)
                {
                    //listbox4_rules_completion(i);//добавляем в список используемых правил
                    string rule_id = rules.ElementAt(i).Key;
                    List<string> rule = rules.ElementAt(i).Value;
                    List<string> children = new List<string>();
                    for (int j = 1; j < rule.Count; j++)
                    {
                        children.Add(rule[j]);
                    }
                    for (int j = 0; j < children.Count; j++)
                    {
                        List<TreeFactsNode> empty_node_list = new List<TreeFactsNode>();
                        TreeFactsNode c = new TreeFactsNode(root, children[j], empty_node_list);
                        root.Children.Add(c);
                        using_facts.Add(c.Value);
                        Addition_using_facts_recurse(c);
                    }
                }
            }
        }
        /// <summary>
        /// строит дерево целевого факта
        /// </summary>
        /// <param name="root"></param>
        private void Recurse(TreeFactsNode root)
        {
            if (root == null) return;

            if (using_facts.Contains(root.Value))
                root.IsCover = true;

            for (int i = 0; i < rules.Keys.Count; i++)//идем по правилам
            {
                string key_fact = rules.ElementAt(i).Value[0];
                if (key_fact == root.Value)
                {
                    string rule_id = rules.ElementAt(i).Key;
                    List<string> rule = rules.ElementAt(i).Value;
                    for (int j = 1; j < rule.Count; j++)
                    {
                        List<TreeFactsNode> empty_node_list = new List<TreeFactsNode>();
                        TreeFactsNode c = new TreeFactsNode(root, rule[j], empty_node_list);
                        root.Children.Add(c);
                        Recurse(c);
                    }
                    if (root.Children.Where(x => x.IsCover == true).Count() == 2)//если дочерние узлы отмечены, то отмечаем родителя
                        root.IsCover = true;
                }
            }
        }
        /// <summary>
        /// заполняет список правил, учавствующих в построении дерева целевого факта
        /// </summary>
        /// <param name="root"></param>
        private void Print(TreeFactsNode root)
        {
            if(root.Children.Count == 0)
            {
                return;
            }
            
            Print(root.Children[0]);
            Print(root.Children[1]);

            string rule = inverseDic_facts[root.Children[0].Value] + " + " + inverseDic_facts[root.Children[1].Value] + " = " + inverseDic_facts[root.Value];

            listBox4_rules.Items.Add(rule);

            if (root.Children.Count > 2)
            {
                Print(root.Children[2]);
                Print(root.Children[3]);

                rule = inverseDic_facts[root.Children[2].Value] + " + " + inverseDic_facts[root.Children[3].Value] + " = " + inverseDic_facts[root.Value];

                listBox4_rules.Items.Add(rule);
            }
        }

        private void Print(int i)
        {
            string rule_id = rules.ElementAt(i).Key;
            string rule = "";
            for (int j = 1; j < rules[rule_id].Count; j++)
            {
                rule += inverseDic_facts[rules[rule_id][j]].ToString() + " ";
                if (j != rules[rule_id].Count - 1)
                    rule += "+ ";
            }
            rule += " = " + inverseDic_facts[rules[rule_id][0]].ToString();
            listBox4_rules.Items.Add(rule);
        }
        private void clear_Click(object sender, EventArgs e)
        {
            using_facts.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4_rules.Items.Clear();
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            string fact = listBox2.SelectedItem.ToString();
            string fact_id = facts[fact].ToString();
            listBox2.Items.Remove(fact);
            using_facts.Remove(fact_id);
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
