using System;
using System.Net;
using System.Net.Http;


class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("httplistener");
        String[] s3_facts = new String[] {
            "Scale storage resources to meet fluctuating needs with 99.999999999% (11 9s) of data durability.",
            "Store data across Amazon S3 storage classes to reduce costs without upfront investment or hardware refresh cycles.",
            "Protect your data with unmatched security, compliance, and audit capabilities.",
            "Easily manage data at any scale with robust access controls, flexible replication tools, and organization-wide visibility.",
            "Run big data analytics, artificial intelligence (AI), machine learning (ML), and high performance computing (HPC) applications.",
            "Meet Recovery Time Objectives (RTO), Recovery Point Objectives (RPO), and compliance requirements with S3’s robust replication features.",
            "Amazon S3 Access Grants map identities in directories such as Active Directory, or AWS Identity and Access Management (IAM) Principals, to datasets in S3.",
            "S3 Access Points, a feature of S3, simplify data access for any AWS service or customer application that stores data in S3",
            "S3 Batch Operations is an Amazon S3 data management feature that lets you manage billions of objects at scale with just a few clicks in the Amazon S3 Management Console or a single API request",
            "Mountpoint for Amazon S3 is an open source file client that you can use to mount an S3 bucket on your compute instance and access it as a local file system",
            "Multi-Region Access Points provide a global endpoint for routing Amazon S3 request traffic between AWS Regions",
            "With S3 Object Lambda, you can add your own code to S3 GET, HEAD, and LIST requests to modify and process data as it is returned to an application",
            "You can configure Amazon S3 to automatically replicate S3 objects across different AWS Regions by using S3 Cross-Region Replication (CRR) or between buckets in the same AWS Region by using S3 Same-Region Replication (SRR)",
            "S3 Storage Lens delivers organization-wide visibility into object storage usage, activity trends, and makes actionable recommendations to optimize costs and apply data protection best practices"
        };

        var listener = new HttpListener();
        listener.Prefixes.Add(string.Format("http://*:8002/"));
        listener.Start();

        try
        {
            while (true)
            {
                HttpListenerContext ctx = listener.GetContext();
                using HttpListenerResponse response = ctx.Response;

                response.StatusCode = (int)HttpStatusCode.OK;
                response.StatusDescription = "Status OK";

                Random rnd = new Random();
                int i = rnd.Next(0, s3_facts.Length - 1);

                Console.WriteLine(i);
                Console.WriteLine(s3_facts[i]);

                byte[] buffer = System.Text.Encoding.UTF8.GetBytes( DateTime.Now.TimeOfDay + " - " + s3_facts[i] );
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                response.OutputStream.Close();

            }
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.ToString());
        }
        finally
        {
            listener.Close();
        }


    }
}


