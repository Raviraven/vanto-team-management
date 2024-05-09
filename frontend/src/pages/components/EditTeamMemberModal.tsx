import { Member } from "api/types";
import { Box, Button, Modal } from "@mui/material";

interface EditTeamMemberModalProps {
  memberId: string;
  //member: Member;
  modalOpened: boolean;
  setModalOpened: (value: boolean) => void;
}

export const EditTeamMemberModal = (props: EditTeamMemberModalProps) => {
  const { memberId, modalOpened, setModalOpened } = props;

  const handleCancel = () => {
    setModalOpened(false);
  };

  return (
    <Modal open={modalOpened} onClose={handleCancel}>
      <Box sx={{ backgroundColor: "#FCFCFC" }}>
        <Button onClick={() => setModalOpened(false)}>Zamknij</Button>
      </Box>
    </Modal>
  );
};
