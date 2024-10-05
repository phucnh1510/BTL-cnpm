<script>
    import "../CSS/assignment.css";
    import * as Resizable from "$lib/components/ui/resizable";
</script>

<main class="h-screen w-screen">
    <Resizable.PaneGroup direction="horizontal" class="h-full w-full rounded-lg border">
        <Resizable.Pane defaultSize={50} class="resizable-1 h-full">
            <div class="flex h-full items-center justify-center p-6">
                <span class="font-semibold">One</span>
            </div>
        </Resizable.Pane>
        <Resizable.Handle />
        <Resizable.Pane defaultSize={50} class="resizable-1 h-full">
            <Resizable.PaneGroup direction="vertical" class="h-full">
                <Resizable.Pane defaultSize={25} class="h-full">
                    <div class="flex h-full items-center justify-center p-6">
                        <span class="font-semibold">Two</span>
                    </div>
                </Resizable.Pane>
                <Resizable.Handle />
                <Resizable.Pane defaultSize={75} class="h-full">
                    <div class="resizable-1 flex h-full items-center justify-center p-6">
                        <span class="font-semibold">Three</span>
                    </div>
                </Resizable.Pane>
            </Resizable.PaneGroup>
        </Resizable.Pane>
    </Resizable.PaneGroup>
</main>
