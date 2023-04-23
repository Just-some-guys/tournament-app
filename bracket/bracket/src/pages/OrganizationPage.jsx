import React, { useState } from "react";
import { useParams } from "react-router";
import OrganizationBanner from "../components/OrganizationBanner/OrganizationBanner";
import OrganizationBannerWithEditButton from "../components/OrganizationBanner/OrganizationBannerWithEditButton";
import TournamentOverviewTab from "../components/Tournament/OverviewTab/TournamentOverviewTab";
import { Tabs, Tab } from "@mui/material";
import TabPanel from "../components/TabPanel/TabPanel";

const OrganizationPage = () => {
  const { id } = useParams();
  const [value, setValue] = useState(0);

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  function a11yProps(index) {
    return {
      id: `simple-tab-${index}`,
      "aria-controls": `simple-tabpanel-${index}`,
    };
  }

  return (
    <div className="organization-wrapper">
        <div className="organization-banner banner-img">
            <img src="https://blogoflegends.com/files/2020/02/Caitlyn_6.jpg" alt="" />
        </div>
       
            <OrganizationBannerWithEditButton
                logo={
                "https://upload.wikimedia.org/wikipedia/commons/b/b5/LCS_2019_Logo.png"
                }
                title="Organization"
            />       
             <hr></hr>  
             <div></div>
             
      
      
    </div>
  );
};

export default OrganizationPage;