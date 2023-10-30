using DomainLayer.DTO;


namespace DomainLayer
{
    public static class CustomConstant
    {
        public static string RepatOut = "Out";

        public static List<OrganSupportDto> GetOrganSupportList()
        {
            List<OrganSupportDto> lstOrganSupport = new();
            OrganSupportDto temp = new();
            temp.OrganSupportName = "Mechanical ventilation (MV)";
            temp.ID = 1;
            lstOrganSupport.Add(temp);

            OrganSupportDto temp1 = new();
            temp1.OrganSupportName = "Dialysis (RRT)";
            temp1.ID = 2;
            lstOrganSupport.Add(temp1);

            OrganSupportDto temp2 = new();
            temp2.OrganSupportName = "ECMO";
            temp2.ID = 3;
            lstOrganSupport.Add(temp2);

            OrganSupportDto temp3 = new();
            temp3.OrganSupportName = "Therapeutic plasma exchange (TPE)";
            temp3.ID = 4;
            lstOrganSupport.Add(temp3);



            return lstOrganSupport;
        }
    }
}
