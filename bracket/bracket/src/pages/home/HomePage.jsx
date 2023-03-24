import { FormControl, InputLabel, Select, MenuItem } from "@mui/material";
import React, { useEffect, useState } from "react";
import TournamentsList from "../../components/TournamentsList/TournamentsList";

const HomePage = (props) => {
  const [tournaments, setTournaments] = useState([]);
  const [topTournaments, setTopTournaments] = useState([]);
  const [filter, setFilter] = useState();
  const games = ["Все игры", "League of Legends", "", "", "", ""];

  const getTournaments = () => {
    /*fetch(`${process.env.REACT_APP_API_BASE_URL}api/tournament`).then((res) => {
      res.json().then((data) => setTournaments(data));
    });*/
    setTournaments([
      {
        name: "Gesnons tournament",
        game: "League of Legends",
        startDate:
          "Thu Mar 23 2023 10:43:21 GMT+0400 (Самарское стандартное время)",
      },
      {
        name: "Gesnons tournament",
        game: "League of Legends",
        startDate:
          "Thu Mar 23 2023 10:43:21 GMT+0400 (Самарское стандартное время)",
      },
      {
        name: "Gesnons tournament",
        game: "League of Legends",
        startDate:
          "Thu Mar 23 2023 10:43:21 GMT+0400 (Самарское стандартное время)",
      },
      {
        name: "Gesnons tournament",
        game: "League of Legends",
        startDate:
          "Thu Mar 23 2023 10:43:21 GMT+0400 (Самарское стандартное время)",
      },
      {
        name: "Gesnons tournament",
        game: "League of Legends",
        startDate:
          "Thu Mar 23 2023 10:43:21 GMT+0400 (Самарское стандартное время)",
      },
      {
        name: "Gesnons tournament",
        game: "League of Legends",
        startDate:
          "Thu Mar 23 2023 10:43:21 GMT+0400 (Самарское стандартное время)",
      },
      {
        name: "Gesnons tournament",
        game: "League of Legends",
        startDate:
          "Thu Mar 23 2023 10:43:21 GMT+0400 (Самарское стандартное время)",
      },
      {
        name: "Gesnons tournament",
        game: "League of Legends",
        startDate:
          "Thu Mar 23 2023 10:43:21 GMT+0400 (Самарское стандартное время)",
      },
      {
        name: "Gesnons tournament",
        game: "League of Legends",
        startDate:
          "Thu Mar 23 2023 10:43:21 GMT+0400 (Самарское стандартное время)",
      },
      {
        name: "Gesnons tournament",
        game: "League of Legends",
        startDate:
          "Thu Mar 23 2023 10:43:21 GMT+0400 (Самарское стандартное время)",
      },
    ]);
  };
  const getTopTournaments = () => {
    /*fetch(`${process.env.REACT_APP_API_BASE_URL}api/tournament`).then((res) => {
      res.json().then((data) => setTournaments(data));
    });*/
    setTopTournaments([
      {
        name: "Gesnons tournament",
        game: "League of Legends",
        startDate:
          "Thu Mar 23 2023 10:43:21 GMT+0400 (Самарское стандартное время)",
      },
      {
        name: "Gesnons tournament",
        game: "League of Legends",
        startDate:
          "Thu Mar 23 2023 10:43:21 GMT+0400 (Самарское стандартное время)",
      },
      {
        name: "Gesnons tournament",
        game: "League of Legends",
        startDate:
          "Thu Mar 23 2023 10:43:21 GMT+0400 (Самарское стандартное время)",
      },
    ]);
  };
  useEffect(() => {
    getTournaments();
    getTopTournaments();
  }, [filter]);

  return (
    <div className="tournamentPage">
      <div>
        <h1>Предстоящие топовые Турниры</h1>
        <TournamentsList top={true} tournaments={topTournaments} />
      </div>
      <div className="games">
        {games.map((game) => (
          <div className="game">{game}</div>
        ))}
      </div>
      <div className="filters">
        <Select
          fullWidth
          sx={{
            "& .MuiSelect-select .notranslate::after": {
              content: `"Даты"`,
            },
            color: "white",
            ".MuiOutlinedInput-notchedOutline": {
              background: "rgba(217, 217, 217, 0.05)",
              border: "2px solid rgba(255, 255, 255, 0.5)",
              borderRadius: "10px",
            },
            "&.Mui-focused .MuiOutlinedInput-notchedOutline": {
              background: "rgba(217, 217, 217, 0.05)",
              border: "2px solid rgba(255, 255, 255, 0.5)",
              borderRadius: "10px",
            },
            "&:hover .MuiOutlinedInput-notchedOutline": {
              background: "rgba(217, 217, 217, 0.05)",
              border: "2px solid rgba(255, 255, 255, 0.5)",
              borderRadius: "10px",
            },
            ".MuiSvgIcon-root ": {
              fill: "white !important",
            },
            mr: 1,
          }}
        >
          <MenuItem value={"RU"}>RU</MenuItem>
          <MenuItem value={"ENG"}>ENG</MenuItem>
        </Select>
        <Select
          fullWidth
          sx={{
            "& .MuiSelect-select .notranslate::after": {
              content: `"Тип турнира"`,
            },
            color: "white",
            ".MuiOutlinedInput-notchedOutline": {
              background: "rgba(217, 217, 217, 0.05)",
              border: "2px solid rgba(255, 255, 255, 0.5)",
              borderRadius: "10px",
            },
            "&.Mui-focused .MuiOutlinedInput-notchedOutline": {
              background: "rgba(217, 217, 217, 0.05)",
              border: "2px solid rgba(255, 255, 255, 0.5)",
              borderRadius: "10px",
            },
            "&:hover .MuiOutlinedInput-notchedOutline": {
              background: "rgba(217, 217, 217, 0.05)",
              border: "2px solid rgba(255, 255, 255, 0.5)",
              borderRadius: "10px",
            },
            ".MuiSvgIcon-root ": {
              fill: "white !important",
            },
            mr: 1,
          }}
        >
          <MenuItem value={"RU"}>RU</MenuItem>
          <MenuItem value={"ENG"}>ENG</MenuItem>
        </Select>
        <Select
          fullWidth
          sx={{
            "& .MuiSelect-select .notranslate::after": {
              content: `"Сервер"`,
            },
            color: "white",
            ".MuiOutlinedInput-notchedOutline": {
              background: "rgba(217, 217, 217, 0.05)",
              border: "2px solid rgba(255, 255, 255, 0.5)",
              borderRadius: "10px",
            },
            "&.Mui-focused .MuiOutlinedInput-notchedOutline": {
              background: "rgba(217, 217, 217, 0.05)",
              border: "2px solid rgba(255, 255, 255, 0.5)",
              borderRadius: "10px",
            },
            "&:hover .MuiOutlinedInput-notchedOutline": {
              background: "rgba(217, 217, 217, 0.05)",
              border: "2px solid rgba(255, 255, 255, 0.5)",
              borderRadius: "10px",
            },
            ".MuiSvgIcon-root ": {
              fill: "white !important",
            },
            mr: 1,
          }}
        >
          <MenuItem value={"RU"}>RU</MenuItem>
          <MenuItem value={"ENG"}>ENG</MenuItem>
        </Select>
      </div>
      <TournamentsList tournaments={tournaments} />
    </div>
  );
};

export default HomePage;
