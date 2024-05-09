import { GetTeamMembers } from "api/teams-service";
import { TempConst } from "TempConst";
import { useEffect, useState } from "react";
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

export const TeamDetails = () => {
  const [teamMembers, setTeamMembers] = useState<Member[]>([]);
  const [editMemberModalOpened, setEditMemberModalOpened] = useState(false);
  const [memberIdToEdit, setMemberIdToEdit] = useState<string>("");
  // add loading states
  // adding data to redux

  const fetchTeamMembers = async () => {
    setTeamMembers(await GetTeamMembers(TempConst.HardcodedTeamId));
  };

  const handleEditMember = (memberId: string) => {
    setMemberIdToEdit(memberId);
    setEditMemberModalOpened(true);
  };

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
                {teamMembers.map((member, i) => {
                  return (
                    <TableRow
                      key={`${member.firstName}${member.lastName}-${i}`}
                    >
                      <TableCell
                        component={"th"}
                        scope={"row"}
                        onClick={() => handleEditMember(member.id)}
                      >
                        {`${member.firstName} ${member.lastName}`}
                      </TableCell>
                      <TableCell>{member.email}</TableCell>
                      <TableCell>{member.phoneNumber}</TableCell>
                      <TableCell>{member.status}</TableCell>
                      <TableCell>{member.createdAt.toString()}</TableCell>
                      <TableCell>...</TableCell>
                    </TableRow>
                  );
                })}
              </TableBody>
            </Table>
          </TableContainer>
        </Grid>
      </Grid>

      <EditTeamMemberModal
        memberId={memberIdToEdit}
        modalOpened={editMemberModalOpened}
        setModalOpened={setEditMemberModalOpened}
      />
    </>
  );
};
