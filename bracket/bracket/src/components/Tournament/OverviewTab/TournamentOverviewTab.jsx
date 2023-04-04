import React, { useEffect, useState } from "react";
import { Tabs, Tab } from "@mui/material";
import TabPanel from "../../TabPanel/TabPanel";

const TournamentOverviewTab = () => {
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
    <div className="overview-tab">
      <img src="https://blogoflegends.com/files/2020/02/Caitlyn_6.jpg" alt="" />
      <div className="tab-background">
        <Tabs
          centered
          value={value}
          textColor="white"
          onChange={handleChange}
          aria-label="basic tabs example"
        >
          <Tab label="Детали" {...a11yProps(0)} />
          <Tab label="Правила" {...a11yProps(1)} />
          <Tab label="Призы" {...a11yProps(2)} />
          <Tab label="Расписание" {...a11yProps(3)} />
          <Tab label="Связь" {...a11yProps(4)} />
          <Tab label="Играть" {...a11yProps(5)} />
        </Tabs>
        <TabPanel value={value} index={0}>
          <div>
            <div className="panel-field">
              <span>Регион</span>
              <span>EU West</span>
            </div>
            <div className="panel-field">
              <span>Дата и время</span>
              <span>25.03.2023 16:00</span>
            </div>
            <div className="panel-field">
              <span>Формат туринра</span>
              <span>5vs5</span>
            </div>
            <div className="panel-field">
              <span>Регистрация</span>
              <span>Открыта</span>
            </div>
          </div>
        </TabPanel>
        <TabPanel value={value} index={1}>
          <div>
            <h1>Правила</h1>
          </div>
        </TabPanel>
        <TabPanel value={value} index={2}>
          <div>
            <h1>Призы</h1>
          </div>
        </TabPanel>
        <TabPanel value={value} index={3}>
          <div>
            <h1>Расписание</h1>
          </div>
        </TabPanel>
        <TabPanel value={value} index={4}>
          <div>
            <h1>Связь</h1>
          </div>
        </TabPanel>
      </div>
    </div>
  );
};

export default TournamentOverviewTab;
