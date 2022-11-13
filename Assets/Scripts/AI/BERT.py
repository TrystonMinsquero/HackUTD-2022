import sys
import io

import torch  # pytorch
from transformers import AutoTokenizer, AutoModel  # for embeddings
from sklearn.metrics.pairwise import cosine_similarity  # for similarity
tokenizer = AutoTokenizer.from_pretrained("bert-base-uncased", )
model = AutoModel.from_pretrained("bert-base-uncased", output_hidden_states=True)
def get_embeddings(text, token_length):
    tokens = tokenizer(text, max_length=token_length, padding='max_length', truncation=True)
    output = model(torch.tensor(tokens.input_ids).unsqueeze(0),
                   attention_mask=torch.tensor(tokens.attention_mask).unsqueeze(0)).hidden_states[-1]
    return torch.mean(output, axis=1).detach().numpy()

while True:
    num = int(input())
    str = input()
    
    token_length=20
    out1 = get_embeddings(str, token_length=token_length)
    
    out = []
    for n in range(num):
        str2 = input()
        # compare str to str2
        out2 = get_embeddings(str2, token_length=token_length)
        similarity = cosine_similarity(out1,out2)[0][0]
        out.append(similarity)
    
    l = ""
    for i in out:
        l += f'{i:.5f}:'
    print(l)
    sys.stdout.flush()