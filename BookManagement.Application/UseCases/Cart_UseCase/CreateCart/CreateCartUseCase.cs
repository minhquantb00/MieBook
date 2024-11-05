using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Cart_UseCase.CreateCart
{
    public class CreateCartUseCase : IUseCase<CreateCartUseCaseInput, CreateCartUseCaseOutput>
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<User> _userRepository;

        public CreateCartUseCase(IRepository<Cart> cartRepository, IRepository<User> userRepository)
        {
            _cartRepository = cartRepository;
            _userRepository = userRepository;
        }
        public async Task<CreateCartUseCaseOutput> ExcuteAsync(CreateCartUseCaseInput input)
        {
            CreateCartUseCaseOutput result = new CreateCartUseCaseOutput
            {
                Succeeded = false,
            };
            var user = await _userRepository.GetByIdAsync(input.UserId);
            if(user == null)
            {
                result.Errors = new string[] { "Người dùng không tồn tại" };
                return result;
            }
            Cart cart = new Cart
            {
                CreateTime = DateTime.Now,
                UserId = input.UserId,
            };
            cart = await _cartRepository.CreateAsync(cart);
            result.Succeeded = true;
            return result;
        }

        public Task<CreateCartUseCaseOutput> ExcuteAsync(long? id, CreateCartUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
