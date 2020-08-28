using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using DataAccessLayer.Dao;
using DataAccessLayer.Mapper;
using Entities;

namespace DataAccessLayer.CRUD {
    public class ReglaCrudFactory : CrudFactory {
        ReglaMapper mapper;

        CantonMapper cantonMapper;
        DistritoMapper distritoMapper;

        public ReglaCrudFactory() {
            this.mapper = new ReglaMapper();

            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity) {
            var regla = (Regla)entity;
            var sqlOperation = mapper.GetCreateStatement(regla);

            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity) {
            var regla = (Regla)entity;
            var sqlOperation = mapper.GetDeleteStatement(regla);

            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity) {
            throw new NotImplementedException();
        }

        public List<T> RetrieveBySucursal<T>(int sucursalId) {
            var lstRegla = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveBySucursalStatement(sucursalId));
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0) {
                var objs = mapper.BuildObjects(lstResult);

                foreach (var c in objs) {
                    lstRegla.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstRegla;
        }

        public override List<T> RetrieveAll<T>() {
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entity) {
            var regla = (Regla)entity;
            var sqlOperation = mapper.GetUpdateStatement(regla);

            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
