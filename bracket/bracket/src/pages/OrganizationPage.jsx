import React, { useState, useEffect } from "react";
import { useParams } from "react-router";
import OrganizationBanner from "../components/OrganizationBanner/OrganizationBanner";
import TournamentOverviewTab from "../components/Tournament/OverviewTab/TournamentOverviewTab";
import OrganizationApi from "../api/OrganizationApi";
import { Tabs, Tab } from "@mui/material";
import TabPanel from "../components/TabPanel/TabPanel";
import OrganizationInfo from "../components/Organization/OrganizationInfo";
import OrganizationTournamentList from "../components/OrganizationTournamentList/OrganizationTournamentList";

const OrganizationPage = () => {
  const { id } = useParams();
  const [organization, setOrganization] = useState([]);

  const getOrganization = (id) => {
    OrganizationApi.GetOrganization(id).then((result) =>
    {console.log(result);
    setOrganization(result.data)}
    );
  };

  useEffect(() => {
    getOrganization(id);    
  }, []); 

  /*function a11yProps(index) {
    return {
      id: `simple-tab-${index}`,
      "aria-controls": `simple-tabpanel-${index}`,
    };
  }*/

  return (
    <div className="organization-wrapper">

      <OrganizationInfo organization={organization}>
        
      </OrganizationInfo> 

      <hr></hr>                
      
      <h2>Текущие турниры</h2>
      <OrganizationTournamentList organizationId={id} status={2} />
      <h2>Завершенные турниры</h2> 
      <OrganizationTournamentList organizationId={id} status={1} />
      <h2>Предстоящие турниры</h2> 
      <OrganizationTournamentList organizationId={id} status={0} />
      
    </div>
  );
};

export default OrganizationPage;