using elasticsearch_asp.net_mvc.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;

namespace elasticsearch_asp.net_mvc.Controllers
{
    public class SearchController : Controller
    {
        
        private Uri node = null;
        private ConnectionSettings settings;
        private ElasticClient client; 

        // GET: Search
        public ActionResult Index(string query, int? pageNum)
        {
            int listCount = Convert.ToInt32(WebConfigurationManager.AppSettings["ListCount"]);
            string searchServer = WebConfigurationManager.AppSettings["SearchServer"];
            string searchPort = WebConfigurationManager.AppSettings["SearchPort"];
            node = new Uri(searchServer + ":" + searchPort);

            settings = new ConnectionSettings(node);
            client = new ElasticClient(settings);
            List<Search> result = new List<Search>();
            pageNum = pageNum == null ? 1 : pageNum;            
            int startNo = (((int)pageNum * listCount) - listCount) + 1;
            long totalCount = 0L;

            if (!string.IsNullOrEmpty(query))
            {
                var searchResponse = client.Search<Search>(s => s
                    .AllTypes()
                    .Index("blogs")
                    .From(startNo)
                    .Size(listCount) 
                    .Query(q => q
                        .MultiMatch(m => m
                            .Fields(fs => fs
                                .Field(p => p.title)
                                .Field(p => p.desc)
                             )
                             
                             .Query(query)
                        )
                    )
                    .Highlight(h => h
                        .PreTags("<strong>")
                        .PostTags("</strong>")
                        .Fields(fs => fs
                            .Field(p => p.title)
                            .Type(HighlighterType.Unified)
                            .Field(p => p.desc)
                            .Type(HighlighterType.Unified)
                        )
                     )
                );

                totalCount = searchResponse.Total;
                result = searchResponse.Documents.ToList(); 
            }

            int pageCount = ((int)totalCount / listCount);

            if (((int)totalCount % listCount) > 0)
            {
                pageCount++;
            }
            
            ViewBag.query = query;
            ViewBag.totalCount = totalCount;
            ViewBag.pageCount = pageCount;
            ViewBag.pageNum = pageNum; 

            return View(result); 
        }
    }
}