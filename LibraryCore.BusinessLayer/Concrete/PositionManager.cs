﻿using LibraryCore.BusinessLayer.Abstract;
using LibraryCore.BusinessLayer.Results;
using LibraryCore.DataAccessLayer.Abstract;
using LibraryCore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore.BusinessLayer.Concrete
{
    public class PositionManager : IPositionService
    {
        IPositionDal _positionDal;

        public PositionManager(IPositionDal positionDal)
        {
            _positionDal = positionDal;
        }


        public IResult Add(Position position)
        {
            position.Name.ToUpper();
            _positionDal.Add(position);
            return new SuccessResult();
        }

        public IDataResult<List<Position>> GetAllByStatus()
        {
            return new SuccessDataResult<List<Position>>(_positionDal.GetAll(p => p.Status == true));
        }

        public IDataResult<Position> GetById(int id)
        {
            return new SuccessDataResult<Position>(_positionDal.Get(p => p.Id == id));
        }

        public IDataResult<Position> GetByName(string positionName)
        {
            return new SuccessDataResult<Position>(_positionDal.Get(p => p.Name.Contains(positionName)));
        }

        public IResult Update(Position position)
        {
            position.Name.ToUpper();
            _positionDal.Update(position);
            return new SuccessResult();
        }
    }
}
