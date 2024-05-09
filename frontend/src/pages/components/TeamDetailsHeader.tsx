import { Box, Button, Typography } from "@mui/material";
import { AddTeamMemberModal } from "./AddTeamMemberModal";
import { useState } from "react";

interface TeamDetailsHeaderProps {
  teamId: string;
}

export const TeamDetailsHeader = (props: TeamDetailsHeaderProps) => {
  const { teamId } = props;
  const [newMemberModalOpened, setNewMemberModalOpened] = useState(false);

  const openAddNewMemberModal = () => {
    setNewMemberModalOpened(true);
  };

  return (
    <>
      <Box sx={{ display: "flex", justifyContent: "space-between" }}>
        <Box component={"section"}>
          <Typography variant={"h4"}>Lista członków zespołu</Typography>
          <Typography variant={"body1"}>
            Zarządzaj listą członków swojego zespołu
          </Typography>
        </Box>

        <Box>
          <Button>Zaimportuj członka zespołu</Button>
          <Button onClick={openAddNewMemberModal}>Dodaj członka zespołu</Button>
        </Box>
      </Box>
      <AddTeamMemberModal
        teamId={teamId}
        open={newMemberModalOpened}
        setOpen={setNewMemberModalOpened}
      />
    </>
  );
};
