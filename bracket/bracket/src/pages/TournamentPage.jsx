import React, { useState } from "react";
import { useParams } from "react-router";
import OrganizationBanner from "../components/OrganizationBanner/OrganizationBanner";
import TournamentOverviewTab from "../components/Tournament/OverviewTab/TournamentOverviewTab";
import { Tabs, Tab } from "@mui/material";
import TabPanel from "../components/TabPanel/TabPanel";

const TournamentPage = () => {
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
    <div className="tournament-wrapper">
      <OrganizationBanner
        logo={
          "https://upload.wikimedia.org/wikipedia/commons/b/b5/LCS_2019_Logo.png"
        }
        title="Organization"
      />
      <h1>Gesnon's tournament 5vs5 25.03.2023</h1>
      <Tabs
        centered
        textColor="white"
        value={value}
        onChange={handleChange}
        aria-label="basic tabs example"
      >
        <Tab label="Обзор" {...a11yProps(0)} />
        <Tab label="Участники" {...a11yProps(1)} />
        <Tab label="Сетка" {...a11yProps(2)} />
        <Tab label="Статистика" {...a11yProps(2)} />
        <Tab label="Объявления" {...a11yProps(3)} />
      </Tabs>

      <TabPanel value={value} index={0}>
        <TournamentOverviewTab />
      </TabPanel>
    </div>
  );
};

export default TournamentPage;
