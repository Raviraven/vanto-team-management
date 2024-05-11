import { Member } from "api/types";
import { Box, Button, Grid, Modal, Typography } from "@mui/material";
import { useForm } from "react-hook-form";
import { InputFormField } from "../../components/form/InputFormField";
import { GetMemberDetails, UpdateMember } from "../../api/members-service";
import React, { useEffect, useState } from "react";

interface EditTeamMemberModalProps {
  memberId: string;
  //member: Member;
  open: boolean;
  setOpen: (value: boolean) => void;
}

export const EditTeamMemberModal = (props: EditTeamMemberModalProps) => {
  const { memberId, open, setOpen } = props;
  const [status, setStatus] = useState("");
  const { handleSubmit, control, formState, reset, setValue } = useForm<Member>(
    {
      defaultValues: {
        id: memberId,
        firstName: "",
        lastName: "",
        email: "",
        phoneNumber: "",
        status: "",
        createdAt: null!,
      },
    },
  );

  const fetchUserData = async () => {
    const result = await GetMemberDetails(memberId);
    //setMember(result);

    setStatus(result.status);

    setValue("firstName", result.firstName);
    setValue("lastName", result.lastName);
    setValue("email", result.email);
    setValue("phoneNumber", result.phoneNumber);
    setValue("status", result.status);
    setValue("createdAt", result.createdAt);
  };

  const handleClose = () => {
    setOpen(false);
    reset();
  };

  const handleUpdateMember = async (data: Member) => {
    await UpdateMember(data);
    setOpen(false);
    reset();
  };

  useEffect(() => {
    if (memberId === "") {
      return;
    }

    void fetchUserData();
  }, []);

  return (
    <Modal open={open} onClose={handleClose}>
      <Grid
        container
        flexDirection={"column"}
        sx={{ backgroundColor: "#FCFCFC" }}
      >
        <Grid item>
          <Typography variant={"h6"}>
            Dodawanie nowego członka zespołu
          </Typography>
          <Typography variant={"body2"}>
            Wypełnij wszystkie pola poniżej lub pobierz z internetu
          </Typography>
        </Grid>

        <Grid item display={"grid"} gridTemplateColumns={"100px 1fr"}>
          <Box>
            avatar <br />
            {status}
          </Box>

          <Box sx={{ display: "flex", flexDirection: "column", width: "100%" }}>
            <InputFormField
              name={"firstName"}
              label={"Nazwa"}
              control={control}
            />
            <InputFormField
              name={"lastName"}
              label={"Nazwisko"}
              control={control}
            />
            <InputFormField
              name={"email"}
              label={"Adres email"}
              control={control}
            />
            <InputFormField
              name={"phoneNumber"}
              label={"Numer telefonu"}
              control={control}
            />
          </Box>
        </Grid>

        <Grid item>
          <Button onClick={handleClose}>Zamknij</Button>
        </Grid>
      </Grid>
    </Modal>
  );
};
