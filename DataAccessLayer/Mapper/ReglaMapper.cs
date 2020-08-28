using DataAccessLayer.Dao;
using Entities;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Mapper {
    public class ReglaMapper : EntityMapper, ISqlStaments, IObjectMapper {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_ID_SUCURSAL = "ID_SUCURSAL";
        private const string DB_COL_REGLA = "REGLA";
        

        public SqlOperation GetCreateStatement(BaseEntity entity) {
            var operation = new SqlOperation { ProcedureName = "CREAR_REGLA" };

            var r = (Regla)entity;
            operation.AddIntParam(DB_COL_ID_SUCURSAL, r.SucursalId);
            operation.AddVarcharParam(DB_COL_REGLA, r.Detalle);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity) {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveBySucursalStatement(int sucursalId) {
            var operation = new SqlOperation { ProcedureName = "OBTENER_REGLAS_SUCURSAL" };
            operation.AddIntParam(DB_COL_ID_SUCURSAL, sucursalId);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity) {
            var operation = new SqlOperation { ProcedureName = "MODIFICAR_REGLA" };

            var r = (Regla)entity;
            operation.AddIntParam(DB_COL_ID, r.Id);
            operation.AddIntParam(DB_COL_ID_SUCURSAL, r.SucursalId);
            operation.AddVarcharParam(DB_COL_REGLA, r.Detalle);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity) {
            var operation = new SqlOperation { ProcedureName = "ELIMINAR_REGLA" };

            var r = (Regla)entity;
            operation.AddIntParam(DB_COL_ID, r.Id);

            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows) {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows) {
                var regla = BuildObject(row);
                lstResults.Add(regla);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row) {
            var regla = new Regla { 
                Id = GetIntValue(row, DB_COL_ID),
                SucursalId = GetIntValue(row, DB_COL_ID_SUCURSAL),
                Detalle = GetStringValue(row, DB_COL_REGLA)
            };

            return regla;
        }

        public SqlOperation GetRetriveAllStatement() {
            throw new NotImplementedException();
        }
    }
}
