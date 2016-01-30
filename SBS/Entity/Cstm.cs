using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Cstm
    {
        public String cs_no { get; set; }
        public String cs_type { get; set; }
        public String cs_fname { get; set; }
        public String cs_mname { get; set; }
        public String cs_lname { get; set; }
        public String cs_addr1 { get; set; }
        public String cs_addr2 { get; set; }
        public String cs_city { get; set; }
        public String cs_state { get; set; }
        public String cs_zip { get; set; }
        public String cs_branch { get; set; }
        public String cs_phn { get; set; }
        public String cs_email { get; set; }
        public String cs_uid { get; set; }
        public String cs_secq1 { get; set; }
        public String cs_ans1 { get; set; }
        public String cs_secq2 { get; set; }
        public String cs_ans2 { get; set; }
        public String cs_secq3 { get; set; }
        public String cs_ans3 { get; set; }
        public String cs_access { get; set; }

        public String cs_pass { get; set; }
        public String cs_uname { get; set; }
        public String cs_merch { get; set; }
        public Cstm()
        { }
        public Cstm(String a, String b, String c, String d, String e, String f, String g, String h, String i, 
            String j, String k, String l, String m, String n, String o, String p, String q, String r, String s, String t, String u)
        {
            this.cs_no = a;
            this.cs_type = b;
            this.cs_fname = c;
            this.cs_mname = d;
            this.cs_lname = e;
            this.cs_addr1 = f;
            this.cs_addr2 = g;
            this.cs_city = h;
            this.cs_state = i;
            this.cs_zip = j;
            this.cs_branch = k;
            this.cs_phn = l;
            this.cs_email = m;
            this.cs_uid = n;
            this.cs_secq1 = o;
            this.cs_ans1 = p;
            this.cs_secq2 = q;
            this.cs_ans2 = r;
            this.cs_secq3 = s;
            this.cs_ans3 = t;
        }

    }
}
