using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using policecaseapi.Models;
using System.Linq;
using System.Xml.Linq;


namespace policecaseapi.Controllers
{
    [Route("policecase/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class DistrikterController : Controller
    {
        //Returns all districts in distrikter.xml
        [HttpGet]
        public XElement Get()
        {
            XElement distrikterXML = XElement.Load("xml/distrikter.xml");
            return distrikterXML;
        }

        //Creates new district and adds to distrikter.xml
        [HttpPost]
        public XElement Post([FromBody]Sak newSak)
        {
            XElement distrikterXML = XElement.Load("xml/distrikter.xml");

            XElement newDistriktXML = new XElement("distrikt",
                new XElement("id", newSak.Id),
                new XElement("name", newSak.Name)
            );

            distrikterXML.Add(newDistriktXML);
            distrikterXML.Save("xml/distrikter.xml");
            return newDistriktXML;

        }

        //Edits district, located by id, updates values
        [HttpPut]
        public XElement Put([FromBody]Sak putDistrikt)
        {
            XElement distrikterXML = XElement.Load("xml/distrikter.xml");
            
            var distriktToUpdate = (from distrikt in distrikterXML.Descendants("distrikt")
                                 where (int)distrikt.Element("id") == putDistrikt.Id
                                 select distrikt).SingleOrDefault();


            distriktToUpdate.SetElementValue("name", putDistrikt.Name);

            distrikterXML.Save("xml/distrikter.xml");
            
            return distriktToUpdate;

        }

        //deletes single district, located by id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            XElement distrikterXML = XElement.Load("xml/distrikter.xml");
            
            var distriktToDelete = (from distrikt in distrikterXML.Descendants("distrikt")
                                 where (int)distrikt.Element("id") == id
                                 select distrikt).SingleOrDefault();

            distriktToDelete.Remove();
            distrikterXML.Save("xml/distrikter.xml");

        }
        
    }
}
