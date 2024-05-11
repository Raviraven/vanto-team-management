import { GetTeamMembers } from "api/teams-service";
import { TempConst } from "TempConst";
import React, { useCallback, useEffect, useState } from "react";
import { Member } from "api/types";
import {
  Grid,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
} from "@mui/material";
import { TeamDetailsHeader } from "./components/TeamDetailsHeader";
import { EditTeamMemberModal } from "./components/EditTeamMemberModal";
import { TeamMemberRow } from "./components/TeamMemberRow";

export const TeamDetails = () => {
  const [teamMembers, setTeamMembers] = useState<Member[]>([]);
  const [editMemberModalOpened, setEditMemberModalOpened] = useState(false);
  const [memberIdToEdit, setMemberIdToEdit] = useState<string>("");
  // add loading states
  // adding data to redux

  const fetchTeamMembers = async () => {
    setTeamMembers(await GetTeamMembers(TempConst.HardcodedTeamId));
  };

  const handleEditMember = useCallback((memberId: string) => {
    setMemberIdToEdit(memberId);
    setEditMemberModalOpened(true);
  }, []);

  useEffect(() => {
    void fetchTeamMembers();
  }, []);

  return (
    <>
      <Grid container flexDirection={"column"}>
        <Grid item>
          <TeamDetailsHeader teamId={TempConst.HardcodedTeamId} />
        </Grid>

        <Grid item>
          <TableContainer component={Paper}>
            <Table>
              <TableHead>
                <TableRow>
                  <TableCell>Nazwa</TableCell>
                  <TableCell>Adres email</TableCell>
                  <TableCell>Number telefonu</TableCell>
                  <TableCell>Status</TableCell>
                  <TableCell>Data utworzenia</TableCell>
                  <TableCell>Akcje</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {teamMembers.map((member, i) => (
                  <TeamMemberRow
                    key={`${member.firstName}${member.lastName}-${i}`}
                    member={member}
                    handleEditMember={handleEditMember}
                  />
                ))}
              </TableBody>
            </Table>
          </TableContainer>
        </Grid>
      </Grid>

      {editMemberModalOpened && (
        <EditTeamMemberModal
          memberId={memberIdToEdit}
          open={editMemberModalOpened}
          setOpen={setEditMemberModalOpened}
        />
      )}
    </>
  );
};
