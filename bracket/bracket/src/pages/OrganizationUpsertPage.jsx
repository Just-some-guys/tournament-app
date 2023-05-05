import { Tab, Tabs, TextField, Button } from "@mui/material";
import React, { useState } from "react";

const TabPanel = (props) => {
  const { children, value, index, ...other } = props;
  return (
    <div hidden={value !== index}>
      {value === index && <div>{children}</div>}
    </div>
  );
};

const OrganizationUpsertPage = (props) => {
  const [data, setData] = useState({
    logo: "",
    headerImage: "",
    name: "",
    description: "",
  });
  const [value, setValue] = React.useState(0);

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  const saveChanges = () => {
    fetch("https://localhost:7143/api/Organization", {
      headers: {
        "content-type": "application/json",
      },
      body: JSON.stringify(data),
      method: "POST",
    });
  };

  const toBase64 = (file) =>
    new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => resolve(reader.result);
      reader.onerror = reject;
    });

  return (
    <div className="organization-wrapper">
      <h1>Создание турнира</h1>
      <Tabs value={value} onChange={handleChange}>
        <Tab label="Основная информация" />
        <Tab label="Контакты" />
        <Tab label="Сотрудники" />
      </Tabs>

      <TabPanel value={value} index={0}>
        <div
          style={{
            display: "flex",
            flexDirection: "column",
            gap: "20px",
            backgroundColor: "white",
          }}
        >
          <Button variant="contained" component="label">
            Загрузите логотип
            <input
              type="file"
              hidden
              onChange={async (e) => {
                if (e.target.files) {
                  setData({ ...data, logo: await toBase64(e.target.files[0]) });
                }
              }}
            />
          </Button>
          <TextField
            value={data.name}
            onChange={(e) => setData({ ...data, name: e.target.value })}
            placeholder="Введите название вашей организации"
            label="Название организации"
          />
          <TextField
            value={data.description}
            onChange={(e) => setData({ ...data, description: e.target.value })}
            placeholder="Введите описание вашей организации"
            label="Описание организации"
          />
          <Button variant="contained" component="label">
            Загрузите заглавное изображение
            <input
              type="file"
              hidden
              onChange={async (e) => {
                if (e.target.files) {
                  setData({
                    ...data,
                    headerImage: await toBase64(e.target.files[0]),
                  });
                }
              }}
            />
          </Button>
          <Button onClick={saveChanges}>Save</Button>
        </div>
      </TabPanel>
      <TabPanel value={value} index={1}>
        Item Two
      </TabPanel>
      <TabPanel value={value} index={2}>
        Item Three
      </TabPanel>
    </div>
  );
};

export default OrganizationUpsertPage;
