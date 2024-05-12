import { TextField } from "@mui/material";
import { Controller } from "react-hook-form";

interface InputFormFieldProps {
  name: string;
  label: string;
  control: any;
}

export const InputFormField = (props: InputFormFieldProps) => {
  const { name, label, control } = props;

  return (
    <Controller
      name={name}
      control={control}
      render={({ field: { value, onChange } }) => (
        <TextField
          label={label}
          variant={"outlined"}
          fullWidth
          margin={"none"}
          onChange={onChange}
          value={value}
          size={"small"}
        />
      )}
    />
  );
};
