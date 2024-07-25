import {
  Datagrid,
  List,
  TextField,
  Count,
  FunctionField,
  ReferenceManyCount,
} from "react-admin";

export const CampanhaList = () => {
  return (
    <List>
      <Datagrid>
        <TextField source="id" />
        <TextField source="descricao" />
      </Datagrid>
    </List>
  );
};
