using system;
using system.collections.generic;
using system.linq;
using system.threading.tasks;
using microsoft.aspnetcore.http;
using microsoft.aspnetcore.mvc;
using microsoft.entityframeworkcore;
using ressourcesrelationnellesapi.models;

namespace ressourcesrelationnellesapi.controllers
{
    [route("api/[controller]")]
    [apicontroller]
    public class chatscontroller : controllerbase
    {
        private readonly datacontext _context;

        public chatscontroller(datacontext context)
        {
            _context = context;
        }

        // get: api/chats
        [httpget]
        public async task<actionresult<ienumerable<chat>>> getchats()
        {
            return await _context.chats.tolistasync();
        }

        // get: api/chats/5
        [httpget("{id}")]
        public async task<actionresult<chat>> getchat(uint id)
        {
            var chat = await _context.chats.findasync(id);

            if (chat == null)
            {
                return notfound();
            }

            return chat;
        }

        // put: api/chats/5
        // to protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [httpput("{id}")]
        public async task<iactionresult> putchat(uint id, chat chat)
        {
            if (id != chat.id_chat)
            {
                return badrequest();
            }

            _context.entry(chat).state = entitystate.modified;

            try
            {
                await _context.savechangesasync();
            }
            catch (dbupdateconcurrencyexception)
            {
                if (!chatexists(id))
                {
                    return notfound();
                }
                else
                {
                    throw;
                }
            }

            return nocontent();
        }

        // post: api/chats
        // to protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [httppost]
        public async task<actionresult<chat>> postchat(chat chat)
        {
            _context.chats.add(chat);
            await _context.savechangesasync();

            return createdataction("getchat", new { id = chat.id_chat }, chat);
        }

        // delete: api/chats/5
        [httpdelete("{id}")]
        public async task<iactionresult> deletechat(uint id)
        {
            var chat = await _context.chats.findasync(id);
            if (chat == null)
            {
                return notfound();
            }

            _context.chats.remove(chat);
            await _context.savechangesasync();

            return nocontent();
        }

        private bool chatexists(uint id)
        {
            return _context.chats.any(e => e.id_chat == id);
        }
    }
}
