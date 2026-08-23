using JournalApp.Domain.Journal;
using MediatR;

namespace JournalApp.Application.Commands.Journals.GetAll;

public class GetAllJournalsCommand : IRequest<List<Journal>>
{
}