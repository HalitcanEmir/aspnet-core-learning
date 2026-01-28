import SectionWrapper from "./SectionWrapper";

const steps = [
  {
    title: "Pitch",
    description:
      "Ideas and briefs come from inside the studio or from partners — small, clear and prototype-friendly.",
    icon: "💡",
  },
  {
    title: "Crew Forming",
    description:
      "We assemble a temporary crew with the right mix of developers, designers, artists and operators.",
    icon: "🧩",
  },
  {
    title: "Build & Playtest",
    description:
      "Tight loops, early playtests and constant feedback. We expect change, not perfection on v1.",
    icon: "🛠",
  },
  {
    title: "Ship & Learn",
    description:
      "We ship, collect telemetry and run retros. Learnings feed the next crews and experiments.",
    icon: "📡",
  },
];

export default function Process() {
  return (
    <SectionWrapper id="process" className="space-y-10">
      <div className="space-y-3">
        <p className="text-[11px] font-semibold uppercase tracking-[0.3em] text-slate-400">
          Process
        </p>
        <h2 className="text-2xl font-semibold uppercase tracking-[0.18em] text-slate-100 sm:text-3xl">
          How a crew builds a product
        </h2>
      </div>

      <div className="relative grid gap-6 md:grid-cols-[auto,1fr]">
        <div className="relative hidden md:block">
          <div className="h-full w-px bg-gradient-to-b from-sky-400/40 via-slate-600/40 to-violet-500/40" />
          <div className="absolute -left-1 h-3 w-3 rounded-full bg-sky-400 shadow-[0_0_18px_rgba(56,189,248,0.9)]" />
          <div className="absolute -left-1 bottom-0 h-3 w-3 rounded-full bg-violet-500 shadow-[0_0_18px_rgba(124,58,237,0.9)]" />
        </div>

        <div className="space-y-4">
          {steps.map((step, index) => (
            <div
              key={step.title}
              className="group grid gap-4 md:grid-cols-[auto,1fr]"
            >
              <div className="flex items-start gap-3">
                <div className="relative flex h-9 w-9 items-center justify-center rounded-2xl bg-slate-900/80 text-lg">
                  <span>{step.icon}</span>
                </div>
                <span className="mt-1 text-[11px] font-semibold uppercase tracking-[0.3em] text-slate-400">
                  {String(index + 1).padStart(2, "0")}
                </span>
              </div>
              <div className="glass-panel-subtle relative overflow-hidden rounded-2xl border border-white/8 bg-slate-950/60 p-4 transition group-hover:border-sky-400/70">
                <div className="pointer-events-none absolute inset-0 bg-gradient-to-r from-[#7C3AED]/15 via-transparent to-[#38BDF8]/15 opacity-0 mix-blend-screen transition group-hover:opacity-100" />
                <h3 className="relative text-xs font-semibold uppercase tracking-[0.24em] text-slate-100">
                  {step.title}
                </h3>
                <p className="relative mt-2 text-xs leading-relaxed text-slate-300/90">
                  {step.description}
                </p>
              </div>
            </div>
          ))}
        </div>
      </div>
    </SectionWrapper>
  );
}

