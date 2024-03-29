﻿using FilmClub.Services.Users.Contracts.Dtos;
using FilmClub.Spec.Tests.Users;

namespace FilmClub.Services.Unit.Test.UsersTest
{
    public interface UserService
    {
        Task Add(AddUserDto dto);
        Task<List<GetUserDto>> Get(UserFilterDto? filterDto);

        Task Remove(int id);
        Task Update(int id, UpdateUserDto dto);
    }
}
