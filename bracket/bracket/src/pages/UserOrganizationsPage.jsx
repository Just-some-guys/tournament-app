import React, { useState, useEffect } from "react";
import { useParams } from "react-router";
import OrganizationBanner from "../components/OrganizationBanner/OrganizationBanner";
import TournamentOverviewTab from "../components/Tournament/OverviewTab/TournamentOverviewTab";
import OrganizationApi from "../api/OrganizationApi";
import { Tabs, Tab } from "@mui/material";
import TabPanel from "../components/TabPanel/TabPanel";
import OrganizationInfo from "../components/Organization/OrganizationInfo";
import OrganizationTournamentList from "../components/OrganizationTournamentList/OrganizationTournamentList";
import UserOrganization from "../components/UserOrganization/UserOrganization";

const UserOrganizationsPage = () => {
  const { userId } = useParams();
  const [organizations, setOrganizations] = useState([]);

  const GetUserOrganizations = (userId) => {
    OrganizationApi.GetUserOrganizations(userId).then((result) =>
    {console.log(result);
    setOrganizations(result.data)}
    );
  };

  useEffect(() => {
    GetUserOrganizations(userId);    
  }, []); 


  return (
    <div className="organization-wrapper">

      <h1>Мои Организации</h1>                
      
      <div className={"userOrganization-list"}>
      {organizations.map((organization) => (
        <UserOrganization organization={organization} />
      ))}
    </div>
      
    </div>
  );
};

export default UserOrganizationsPage;