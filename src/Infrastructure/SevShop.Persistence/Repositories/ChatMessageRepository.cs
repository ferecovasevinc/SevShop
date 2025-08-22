using Microsoft.EntityFrameworkCore;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Domain.Entities;
using SevShop.Persistence.Contexts;

namespace SevShop.Persistence.Repositories;

public class ChatMessageRepository : IChatMessageRepository
{
    private readonly SevShopDbContext _context;

    public ChatMessageRepository(SevShopDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ChatMessage chatMessage)
    {
        await _context.ChatMessages.AddAsync(chatMessage);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ChatMessage chatMessage)
    {
        _context.ChatMessages.Remove(chatMessage);
        await _context.SaveChangesAsync();
    }

    public async Task<List<ChatMessage>> GetAllAsync()
    {
        return await _context.ChatMessages
            .Include(c => c.Sender)
            .Include(c => c.Receiver)
            .ToListAsync();
    }

    public async Task<ChatMessage> GetByIdAsync(Guid id)
    {
        return await _context.ChatMessages
            .Include(c => c.Sender)
            .Include(c => c.Receiver)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task UpdateAsync(ChatMessage chatMessage)
    {
        _context.ChatMessages.Update(chatMessage);
        await _context.SaveChangesAsync();
    }
}
