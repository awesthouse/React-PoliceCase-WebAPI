using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using policecaseapi.Models;
using System.Linq;
using System.Xml.Linq;


namespace policecaseapi.Controllers
{
    [Route("policecase/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class SakController : Controller
    {
        //Gets single case by id
        [HttpGet("{id}")]
        public XElement Get(int id)
        {
            XElement sakerXML = XElement.Load("xml/saker.xml");
            
            var sakToGet = (from sak in sakerXML.Descendants("sak")
                                 where (int)sak.Element("id") == id
                                 select sak).SingleOrDefault();

            return sakToGet;

        }

        //Edits case, located by case id, updates values
        [HttpPut]
        public XElement Put([FromBody]Sak putSak)
        {
            XElement sakerXML = XElement.Load("xml/saker.xml");
            
            var sakToUpdate = (from sak in sakerXML.Descendants("sak")
                                 where (int)sak.Element("id") == putSak.Id
                                 select sak).SingleOrDefault();


            sakToUpdate.SetElementValue("name", putSak.Name);
            sakToUpdate.SetElementValue("category", putSak.Category);
            sakToUpdate.SetElementValue("description", putSak.Description);
            sakToUpdate.SetElementValue("policedistrict", putSak.PoliceDistrict);
            sakToUpdate.SetElementValue("report", putSak.Report);
            sakToUpdate.SetElementValue("victims", putSak.Victims);
            sakToUpdate.SetElementValue("suspects", putSak.Suspects);
            sakToUpdate.SetElementValue("offenders", putSak.Offenders);
            sakToUpdate.SetElementValue("issolved", putSak.IsSolved);

            sakerXML.Save("xml/saker.xml");
            
            return sakToUpdate;

        }
    }
}
