import { Button, Grid, Modal, Typography } from "@mui/material";
import { useForm } from "react-hook-form";
import { CreateTeamMember } from "api/types";
import { InputFormField } from "components/form/InputFormField";
import { useCreateTeamMember } from "api/teams-service";
import { useGetRandomUserData } from "api/random-user-service";
import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { setRefetch } from "store/Members.slice";

import "./AddTeamMemberModal.scss";
import { DownloadingOutlined } from "@mui/icons-material";

interface TeamMemberModalProps {
  teamId: string;
  open: boolean;
  setOpen: (value: boolean) => void;
}

export const AddTeamMemberModal = (props: TeamMemberModalProps) => {
  const { teamId, open, setOpen } = props;
  const { handleSubmit, control, reset, setValue } = useForm<CreateTeamMember>({
    defaultValues: {
      teamId: teamId,
      firstName: "",
      lastName: "",
      email: "",
      phoneNumber: "",
    },
  });
  const dispatch = useDispatch();

  const { fetchData: GetRandomUserData, data: randomUserData } =
    useGetRandomUserData();

  const { postData: CreateNewTeamMember } = useCreateTeamMember(teamId);

  const handleGetRandomUser = async () => {
    await GetRandomUserData();
  };

  const handleCancel = () => {
    setOpen(false);
    reset();
  };

  const handleAddMember = async (data: CreateTeamMember) => {
    await CreateNewTeamMember(data);
    dispatch(setRefetch(true));
    setOpen(false);
    reset();
  };

  useEffect(() => {
    if (!randomUserData || randomUserData.results.length === 0) return;

    setValue("firstName", randomUserData.results[0].name.first);
    setValue("lastName", randomUserData.results[0].name.last);
    setValue("email", randomUserData.results[0].email);
    setValue("phoneNumber", randomUserData.results[0].phone);
  }, [randomUserData, setValue]);

  return (
    <Modal
      open={open}
      onClose={handleCancel}
      className={"add-team-member-modal"}
    >
      <Grid container flexDirection={"column"} className={"content"}>
        <Grid item>
          <Typography variant={"h6"} className={"title"}>
            Dodawanie nowego członka zespołu
          </Typography>
          <Typography variant={"body2"} className={"description"}>
            Wypełnij wszystkie pola poniżej lub pobierz z internetu
          </Typography>
        </Grid>

        <Grid item className={"form-container"}>
          <Button
            onClick={handleGetRandomUser}
            startIcon={<DownloadingOutlined />}
            className={"random-data-button"}
          >
            Wypełnij formularz automatycznie
          </Button>
          <Typography variant={"body2"} className={"random-data-description"}>
            Uwaga! Wszystkie pola formularza zostaną nadpisane danymi z
            internetu
          </Typography>

          <div className={"form-inputs"}>
            {/*<Box sx={{ display: "flex", flexDirection: "column" }}>*/}
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
            {/*</Box>*/}
          </div>
        </Grid>

        <Grid item className={"buttons-container"}>
          <Button onClick={handleCancel} className={"cancel-button"}>
            Anuluj
          </Button>
          <Button
            onClick={handleSubmit(handleAddMember)}
            className={"submit-button"}
          >
            Potwierdź
          </Button>
        </Grid>
      </Grid>
    </Modal>
  );
};
