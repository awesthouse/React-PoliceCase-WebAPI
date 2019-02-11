using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using policecaseapi.Models;
using System.Linq;
using System.Xml.Linq;


namespace policecaseapi.Controllers
{
    [Route("policecase/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class SakerController : Controller
    {
        //returns all cases
        [HttpGet]
        public XElement Get()
        {
            XElement sakerXML = XElement.Load("xml/saker.xml");
            return sakerXML;
        }
    
        //creates new case, adds to saker.xml
        [HttpPost]
        public XElement Post([FromBody]Sak newSak)
        {
            XElement sakerXML = XElement.Load("xml/saker.xml");

            XElement newSakXML = new XElement("sak",
                new XElement("id", newSak.Id),
                new XElement("name", newSak.Name),
                new XElement("category", newSak.Category),
                new XElement("description", newSak.Description),
                new XElement ("datecreated", newSak.DateCreated),
                new XElement("policedistrict", newSak.PoliceDistrict),
                new XElement("report", newSak.Report),
                new XElement("victims", newSak.Victims),
                new XElement("suspects", newSak.Suspects),
                new XElement("offenders", newSak.Offenders),
                new XElement("issolved", newSak.IsSolved)
            );

            sakerXML.Add(newSakXML);
            sakerXML.Save("xml/saker.xml");
            return newSakXML;

        }

        //Deletes single case, located by case id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            XElement sakerXML = XElement.Load("xml/saker.xml");
            
            var sakToDelete = (from sak in sakerXML.Descendants("sak")
                                 where (int)sak.Element("id") == id
                                 select sak).SingleOrDefault();

            sakToDelete.Remove();
            sakerXML.Save("xml/saker.xml");

        }
        
    }
}
