import React, { useState, useEffect } from "react";
import { useParams } from "react-router";
import OrganizationBanner from "../components/OrganizationBanner/OrganizationBanner";
import TournamentOverviewTab from "../components/Tournament/OverviewTab/TournamentOverviewTab";
import OrganizationApi from "../api/OrganizationApi";
import { Tabs, Tab } from "@mui/material";
import TabPanel from "../components/TabPanel/TabPanel";
import OrganizationInfo from "../components/Organization/OrganizationInfo";

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
      
    </div>
  );
};

export default OrganizationPage;