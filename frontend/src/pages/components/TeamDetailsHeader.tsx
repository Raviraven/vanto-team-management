import { Box, Button, Typography } from "@mui/material";
import { AddTeamMemberModal } from "./AddTeamMemberModal/AddTeamMemberModal";
import { useState } from "react";
import { AddOutlined, CloudDownloadOutlined } from "@mui/icons-material";
import { useAddRandomTeamMember } from "../../api/teams-service";
import { setRefetch } from "../../store/Members.slice";
import { useDispatch } from "react-redux";

interface TeamDetailsHeaderProps {
  teamId: string;
}

export const TeamDetailsHeader = (props: TeamDetailsHeaderProps) => {
  const { teamId } = props;
  const [newMemberModalOpened, setNewMemberModalOpened] = useState(false);
  const { postData: ImportRandomMember } = useAddRandomTeamMember(teamId);
  const dispatch = useDispatch();

  const openAddNewMemberModal = () => {
    setNewMemberModalOpened(true);
  };

  const addRandomMember = async () => {
    await ImportRandomMember();
    dispatch(setRefetch(true));
  };

  return (
    <>
      <div className={"team-details-header"}>
        {/*<Box sx={{ display: "flex", justifyContent: "space-between" }}>*/}
        <Box component={"section"}>
          <Typography variant={"h4"} className={"title"}>
            Lista członków zespołu
          </Typography>
          <Typography variant={"body1"} className={"description"}>
            Zarządzaj listą członków swojego zespołu
          </Typography>
        </Box>

        <div className={"buttons-container"}>
          <Button
            onClick={addRandomMember}
            startIcon={<CloudDownloadOutlined />}
          >
            Zaimportuj członka zespołu
          </Button>

          <Button onClick={openAddNewMemberModal} startIcon={<AddOutlined />}>
            Dodaj członka zespołu
          </Button>
        </div>
        {/*</Box>*/}
      </div>
      <AddTeamMemberModal
        teamId={teamId}
        open={newMemberModalOpened}
        setOpen={setNewMemberModalOpened}
      />
    </>
  );
};
